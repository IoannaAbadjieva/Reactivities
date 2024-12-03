using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Core
{
    public class ActivityService
    {
        private readonly ReactivitiesContext context;

        public ActivityService(ReactivitiesContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<Activity>> GetActivities()
        {
            return await context.Activities.ToArrayAsync();
        }

        public async Task<Activity?> GetActivity(Guid id)
        {
            return await context.Activities.FindAsync(id);
        }
    }
}