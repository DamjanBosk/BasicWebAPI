using BasicWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasicWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
