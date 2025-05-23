using Microsoft.EntityFrameworkCore;
using OrgDirectoryApi.Models;

namespace OrgDirectoryApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Organization> Organizations { get; set; }
    }
}