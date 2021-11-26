using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.;
using WeeBitsHRService.Data;
using WeeBitsHRService.Model;

namespace WeeBitsHRService.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public EmployeesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            IEnumerable<Employee> employees = (IEnumerable<Employee>) await _context.Users.OfType<Employee>().Include(e => e.Branch).ThenInclude(e => e.JobCategory).ToListAsync();
            return View(employees);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Users.OfType<Employee>()
                .Include(e => e.BranchId).Include(e => e.JobCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["BranchId"] = new SelectList(_context.Set<Branch>(), "Id", "Region");
            ViewData["JobCategoryId"] = new SelectList(_context.Set<JobCategory>(), "Id", "Name");
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,FirstName,LastName,Email,AddressLine1,AddressLine2,Town,PostCode,Country,PhoneNumber,PayrollNumber,IsActive,Position,Salary,DOB,Gender,JoinDate,LeaveDate,JobCategoryId,BranchId")] Employee employee)
        {
            var result = await _userManager.CreateAsync(employee, "def-Password-123");
            return RedirectToAction("Index");
            ViewData["BranchId"] = new SelectList(_context.Set<Branch>(), "Id", "Region", employee.BranchId);
            ViewData["JobCategoryId"] = new SelectList(_context.Set<JobCategory>(), "Id", "Name", employee.JobCategoryId);
            return View(employee);
        }
    }
}
