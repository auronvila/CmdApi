using Microsoft.EntityFrameworkCore;

namespace CmdApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Character> Characters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Use in-memory SQLite database
                optionsBuilder.UseSqlite("Data Source=:memory:");
            }
        }
    }
}
