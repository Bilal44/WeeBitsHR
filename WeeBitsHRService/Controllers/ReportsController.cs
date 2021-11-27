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
using WeeBitsHRService.Model;

namespace WeeBitsHRService.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;

        public ReportsController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IUserStore<IdentityUser> userStore)
        {
            _context = context;
            _userManager = userManager;
            _userStore = userStore;
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
                .Include(e => e.JobCategory).Include(e => e.Branch).ToListAsync();

            ViewData["Count"] = employees.Count;
            
            return View(employees);
        }
    }
}
