using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeeBitsHRService.Data;
using WeeBitsHRService.Models;

namespace WeeBitsHRService.Controllers
{
	[Authorize(Roles = "Manager")]
	public class EmployeesController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly IUserStore<IdentityUser> _userStore;

		public EmployeesController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IUserStore<IdentityUser> userStore)
		{
			_context = context;
			_userManager = userManager;
			_userStore = userStore;
		}

		// GET: Load Manager Menu
		public async Task<IActionResult> Index()
		{
			return View();
		}

		// GET: All Employees
		public async Task<IActionResult> All()
		{
			var employees = await _context.Employees.Include(e => e.JobCategory).Include(e => e.Branch).ToListAsync();
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
		public async Task<IActionResult> Create(Employee employee)
		{
			ViewData["BranchId"] = new SelectList(_context.Set<Branch>(), "Id", "Region", employee.BranchId);
			ViewData["JobCategoryId"] = new SelectList(_context.Set<JobCategory>(), "Id", "Name", employee.JobCategoryId);
			employee.IsActive = true;

			var duplicatePayroll = await _context.Employees.CountAsync(e => e.PayrollNumber == employee.PayrollNumber);
			if (duplicatePayroll > 0)
			{
				TempData["Error"] = $"An employee already exists with payroll number '{employee.PayrollNumber}'. " +
					$"Every employee should have a unique payroll number, please make sure that a new payroll number has been " +
					"assigned to the employee.";
			}

			if (employee.JoinDate.Date > DateTime.Now.Date)
			{
				TempData["Error"] += "<br>Please enter a valid join date.";
			}

			if (employee.DOB > DateTime.Now.AddYears(-15))
			{
				TempData["Error"] += "<br>Please enter a valid date of birth for the employee.";
			}

			if (TempData["Error"] == null)
			{
				await _userStore.SetUserNameAsync(employee, employee.Email, CancellationToken.None);
				employee.CreatedAt = DateTime.Now;
				var currentUser = await _userManager.GetUserAsync(User);
				employee.CreatedBy = currentUser.Id;
				var result = await _userManager.CreateAsync(employee, "Default-pass-123");
				if (result.Succeeded)
				{
					await _userManager.AddToRoleAsync(employee, "Employee");
					TempData["SM"] = $"Successfully added '{employee.FirstName} {employee.LastName} ({employee.PayrollNumber})' as a new employee.";
					return RedirectToAction("CurrentEmployees","Reports");
				}
			}

			return View(employee);
		}
	}
}
