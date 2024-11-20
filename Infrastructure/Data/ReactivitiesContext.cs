namespace Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class ReactivitiesContext : DbContext
    {
        public ReactivitiesContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Activity> Activities { get; set; }
    }
}