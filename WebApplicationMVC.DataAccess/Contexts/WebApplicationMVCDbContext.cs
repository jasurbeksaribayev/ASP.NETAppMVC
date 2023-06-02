using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.DataAccess.Contexts
{
    public class WebApplicationMVCDbContext : DbContext
    {
        public WebApplicationMVCDbContext(DbContextOptions<WebApplicationMVCDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Staff> Staffs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Staff>().HasData(
                new Staff
                {
                    Id = 1,
                    FirstName = "Jasurbek",
                    LastName = "Saribayev",
                    Email = "jasurbek@mail.ru"
                },
                    new Staff
                {
                    Id = 2,
                    FirstName = "Jamshid",
                    LastName = "Saribayev",
                    Email = "jamshid@mail.ru"
                });
        }
    }
}
