namespace Core.Services
{
    using System;
    using System.Threading.Tasks;
    using Core.Contracts;
    using Infrastructure.Data;
    using Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ActivityService : IActivityServise
    {
        private readonly ReactivitiesContext context;

        public ActivityService(ReactivitiesContext _context)
        {
            context = _context;
        }

        public async Task<Activity> GetActivityAsync(Guid id)
        {
            return await context.Activities.FindAsync(id);
        }

        public async Task<IEnumerable<Activity>> GetAllActivitiesAsync()
        {
            return await context.Activities.ToArrayAsync();
        }
    }
}