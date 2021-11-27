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

        // GET: Employees
        public async Task<IActionResult> CurrentEmployees(int? branchId)
        {
            var employees = await _context.Employees
                .Where(e => (branchId.HasValue ? e.BranchId == branchId : e.BranchId != null) && e.IsActive)
                .Include(e => e.JobCategory).Include(e => e.Branch).ToListAsync();
            return View(employees);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(string email)
        {
            if (email == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .Where(e => e.Email == email)
                .Include(e => e.Branch).Include(e => e.JobCategory)
                .FirstOrDefaultAsync();
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }
    }
}
