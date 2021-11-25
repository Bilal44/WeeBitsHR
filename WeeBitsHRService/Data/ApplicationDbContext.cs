using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeeBitsHRService.Model;

namespace WeeBitsHRService.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
    }
}