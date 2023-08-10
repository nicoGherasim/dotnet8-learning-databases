using Microsoft.EntityFrameworkCore;

namespace Databases.EntityFrameworkCore
{
    public class DbPracticeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=BooksManagement;User Id=sa;Password=<YOUR_PASSWORD>;TrustServerCertificate=True";
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Book> Books { get; set; }
    }
}
