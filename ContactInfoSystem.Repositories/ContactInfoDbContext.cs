using ContactInfoSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ContactInfoSystem.Repositories
{
    public class ContactInfoDbContext : IdentityDbContext<User, Role, int>
    {
        public ContactInfoDbContext()
        { }
        public ContactInfoDbContext(DbContextOptions<ContactInfoDbContext> options) : base(options)
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Designation> Designations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"{connectionstring}");
            }
        }
    }
}

