namespace Persistence
{
    using Domain;
    using Microsoft.EntityFrameworkCore;

    public class ReactivitiesContext : DbContext
    {
        public ReactivitiesContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Activity> Activities { get; set; }

    }
}