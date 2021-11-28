using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeeBitsHRService.Data;
using WeeBitsHRService.Models;
using WeeBitsHRService.ViewModels;

namespace WeeBitsHRService.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CurrentEmployees
        public async Task<IActionResult> CurrentEmployees(int? branchId)
        {
            var employees = await _context.Employees
                .Where(e => (!branchId.HasValue || e.BranchId == branchId) && e.IsActive)
                .Include(e => e.JobCategory).Include(e => e.Branch).ToListAsync();
            return View(employees);
        }

        // GET: EmployeesDemographics
        public async Task<IActionResult> EmployeesDemographics(Gender? gender, int? startAge, int? endAge)
        {
            var employees = await _context.Employees
                .Where(e => (!startAge.HasValue || e.DOB < DateTime.Now.AddYears(-startAge.Value))
                && (!endAge.HasValue || e.DOB > DateTime.Now.AddYears(-endAge.Value))
                && (!gender.HasValue || e.Gender == gender)
                && e.IsActive)
                .Include(e => e.JobCategory).ToListAsync();

            ViewData["Count"] = employees.Count;
            ViewData["StartAge"] = startAge;
            ViewData["EndAge"] = endAge;
            ViewData["Gender"] = gender;

            return View(employees);
        }

        // GET: AveragePayrate
        public async Task<IActionResult> AveragePayrate(int? branchId)
        {
            var employees = await _context.Employees
                .Where(e => (!branchId.HasValue || e.BranchId == branchId)
                && e.IsActive)
                .Include(e => e.JobCategory).ToListAsync();

            ViewData["AvgPaybyGender"] = employees.GroupBy(e => e.Gender).Select(g => new AveragePayByGenderViewModel { Gender = g.Key, AveragePay = g.Average(e => e.Salary) });
            ViewData["AvgPaybyJob"] = employees.GroupBy(e => e.JobCategory).Select(g => new AveragePayByJobViewModel { JobCategory = g.Key, AveragePay = g.Average(e => e.Salary) });
            ViewData["Branch"] = branchId != null || branchId != 0 ? _context.Branches.FirstOrDefault(b => b.Id == branchId)?.Region : "";

            return View(employees);
        }

        // GET: AbsenteeProfile
        public async Task<IActionResult> AbsenteeProfile(DateTime? startDate, DateTime? endDate)
        {
            var employees = _context.Employees
                .Include(e => e.JobCategory).Where(e => e.IsActive).Include(e => e.Absences
                .Where(a=> !startDate.HasValue || a.DateofAbsence >= startDate
                && (!endDate.HasValue || a.DateofAbsence <= endDate))).ToList();

            var absenteeProfile = employees.GroupBy(e => e.JobCategory).Select(g => new AbsenteeProfileViewModel { JobCategory = g.Key, AverageHoursOfAbsence = g.Average(e => e.Absences.Sum(a => a.NumberOfHours)), TotalEmployees = g.Count() });

            ViewData["StartDate"] = startDate.Value.ToShortDateString();
            ViewData["EndDate"] = endDate.Value.ToShortDateString();

            return View(absenteeProfile);
        }

        // GET: AnnualStaffTurnOver
        public async Task<IActionResult> AnnualStaffTurnover(int? branchId, int? year)
        {
            var model = new AnnualTurnoverViewModel();
            if (year == null || Convert.ToInt32(year) == 0)
            {
                return View(model);
            }

            var initialEmployees = await _context.Employees
                .Where(e => (!branchId.HasValue || e.BranchId == branchId)
                && e.JoinDate.Year < year
                && e.IsActive)
                .Include(e => e.Branch).CountAsync();

            var newEmployees = await _context.Employees
                .Where(e => (!branchId.HasValue || e.BranchId == branchId)
                && e.JoinDate.Year == year
                && e.IsActive)
                .Include(e => e.Branch).CountAsync();

            var employeesLeft = await _context.Employees
                .Where(e => (!branchId.HasValue || e.BranchId == branchId)
                && e.LeaveDate.Value.Year == year)
                .Include(e => e.Branch).CountAsync();

            var averageEmployees = (initialEmployees * 2 + newEmployees - employeesLeft) / 2;
            var annualStaffTurnover = averageEmployees > 0 ? employeesLeft * 100 / averageEmployees : 0;

            var branch = _context.Branches.FirstOrDefault(b => b.Id == branchId)?.Region;
            model = new AnnualTurnoverViewModel(averageEmployees, newEmployees, employeesLeft, annualStaffTurnover, year.Value, branch);
            return View(model);
        }
    }
}
