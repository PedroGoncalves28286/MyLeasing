using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyLeasing.Web.Data.Entities;

namespace MyLeasing.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {

        public DbSet<Lessee> lessees { get; set; }

        public DbSet<Owner> Owners { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {


        }
    }
}
