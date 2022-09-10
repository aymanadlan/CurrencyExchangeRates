using Microsoft.EntityFrameworkCore;
using PGSAssignment.Models;

namespace PGSAssignment.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Rate> Rates { get; set; }
    }
}
