using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeeBitsHRService.Models;

namespace WeeBitsHRService.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Branch> Branches { get; set; }
		public DbSet<JobCategory> JobCategories { get; set; }
	}
}