// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeeBitsHRService.Data;
using WeeBitsHRService.Models;

namespace WeeBitsHRService.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public Employee Model { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Model = await _context.Employees
                .Where(e => e.Email == User.Identity.Name)
                .Include(e => e.Branch).Include(e => e.JobCategory)
                .FirstOrDefaultAsync();

            if (Model == null)
            {
                return NotFound($"Unable to load user with email '{User.Identity.Name}'.");
            }

            return Page();
        }
    }
}
