using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeeBitsHRService.Data;
using WeeBitsHRService.Models;
using WeeBitsHRService.ViewModels;

namespace WeeBitsHRService.Controllers
{
	[Authorize(Roles = "Manager")]
	public class ReportsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ReportsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// GET: CurrentEmployees
		[Route("current-employees")]
		public async Task<IActionResult> CurrentEmployees(int? branch_id)
		{
			var employees = await _context.Employees
				.Where(e => (!branch_id.HasValue || e.BranchId == branch_id) && e.IsActive)
				.Include(e => e.JobCategory).Include(e => e.Branch).OrderByDescending(e => e.CreatedAt).ToListAsync();

			ViewData["Branch"] = branch_id != null || branch_id != 0 ? _context.Branches.FirstOrDefault(b => b.Id == branch_id)?.Region : "";

			return View(employees);
		}

		// GET: EmployeesDemographics
		[Route("employees-demographics")]
		public async Task<IActionResult> EmployeesDemographics(Gender? gender, int? start_age, int? end_age)
		{
			if (start_age.Value > end_age.Value)
			{
				TempData["Warning"] = "The start age is after the end age, it may cause wrong or no data to show up.";
			}

			if (start_age.Value < 15 || end_age.Value < 15)
			{
				TempData["Error"] = "Please enter valid start and end age, it may cause wrong or no data to show up.";
			}

			var employees = await _context.Employees
				.Where(e => (!start_age.HasValue || e.DOB < DateTime.Now.AddYears(-start_age.Value))
				&& (!end_age.HasValue || e.DOB > DateTime.Now.AddYears(-end_age.Value))
				&& (!gender.HasValue || e.Gender == gender)
				&& e.IsActive)
				.Include(e => e.JobCategory).ToListAsync();

			ViewData["Count"] = employees.Count;
			ViewData["StartAge"] = start_age ?? 0;
			ViewData["EndAge"] = end_age ?? 99;
			ViewData["Gender"] = gender;

			return View(employees);
		}

		// GET: AveragePayrate
		[Route("average-payrates")]
		public async Task<IActionResult> AveragePayrate(int? branch_id)
		{
			var employees = await _context.Employees
				.Where(e => (!branch_id.HasValue || e.BranchId == branch_id)
				&& e.IsActive)
				.Include(e => e.JobCategory).ToListAsync();

			ViewData["AvgPaybyGender"] = employees.GroupBy(e => e.Gender).Select(g => new AveragePayByGenderVM { Gender = g.Key, AveragePay = g.Average(e => e.Salary), TotalEmployees = g.Count() });
			ViewData["AvgPaybyJob"] = employees.GroupBy(e => e.JobCategory).Select(g => new AveragePayByJobVM { JobCategory = g.Key, AveragePay = g.Average(e => e.Salary), TotalEmployees = g.Count() });
			ViewData["Branch"] = branch_id != null || branch_id != 0 ? _context.Branches.FirstOrDefault(b => b.Id == branch_id)?.Region : "";

			return View(employees);
		}

		// GET: AbsenteeProfile
		[Route("absentee-profile")]
		public async Task<IActionResult> AbsenteeProfile(DateTime? start_date, DateTime? end_date)
		{
			start_date ??= DateTime.Parse("01/01/2000");
			end_date ??= DateTime.Now;

			if (start_date.Value > end_date.Value)
			{
				TempData["Warning"] = "The start date is after the end date, it may cause wrong or no data to show up.";
			}

			var employees = _context.Employees
				.Include(e => e.JobCategory).Where(e => e.IsActive).Include(e => e.Absences
				.Where(a => !start_date.HasValue || a.DateofAbsence >= start_date
				&& (!end_date.HasValue || a.DateofAbsence <= end_date))).ToList();

			var absenteeProfile = employees.GroupBy(e => e.JobCategory).Select(g => new AbsenteeProfileVM { JobCategory = g.Key, AverageHoursOfAbsence = g.Average(e => e.Absences.Sum(a => a.NumberOfHours)), TotalEmployees = g.Count() });

			ViewData["StartDate"] = start_date.Value.ToShortDateString();
			ViewData["EndDate"] = end_date.Value.ToShortDateString();

			return View(absenteeProfile);
		}

		// GET: AnnualStaffTurnOver
		[Route("annual-staff-turnover")]
		public async Task<IActionResult> AnnualStaffTurnover(int? branch_id, int? year)
		{
			var model = new AnnualTurnoverVM();
			if (year == null || Convert.ToInt32(year) == 0 || Convert.ToInt32(year) < 2000)
			{
				year = DateTime.Now.Year;
				TempData["Error"] = "Pleae enter a valid year.";
			}

			if (year > DateTime.Now.Year)
			{
				TempData["Error"] = "Please enter a valid year, we do not have to capability to peek into the future yet :).";
			}

			var initialEmployees = await _context.Employees
				.Where(e => (!branch_id.HasValue || e.BranchId == branch_id)
				&& e.JoinDate.Year < year
				&& e.IsActive)
				.Include(e => e.Branch).CountAsync();

			var newEmployees = await _context.Employees
				.Where(e => (!branch_id.HasValue || e.BranchId == branch_id)
				&& e.JoinDate.Year == year)
				.Include(e => e.Branch).CountAsync();

			var employeesLeft = await _context.Employees
				.Where(e => (!branch_id.HasValue || e.BranchId == branch_id)
				&& e.LeaveDate.Value.Year == year)
				.Include(e => e.Branch).CountAsync();

			var averageEmployees = (initialEmployees * 2 + newEmployees - employeesLeft) / 2;
			var annualStaffTurnover = averageEmployees > 0 ? (double) employeesLeft / averageEmployees : 0;

			var branch = _context.Branches.FirstOrDefault(b => b.Id == branch_id)?.Region;
			model = new AnnualTurnoverVM(averageEmployees, newEmployees, employeesLeft, annualStaffTurnover, year.Value, branch);
			return View(model);
		}
	}
}
