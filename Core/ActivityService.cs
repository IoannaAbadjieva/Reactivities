namespace Core
{
    using System;
    using System.Threading.Tasks;
    using Infrastructure.Data;
    using Infrastructure.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ActivityService:IActivityService
    {
        private readonly ReactivitiesContext context;

        public ActivityService(ReactivitiesContext _context)
        {
            context = _context;
        }
        public async Task<Activity[]> GetAllActivitiesAsync()
        {
            return await context.Activities.ToArrayAsync();
        }

        public async Task<Activity?> GetActivityAsync(Guid id )
        {
            return await context.Activities.FindAsync(id );
        }

        public async Task AddActivityAsync(Activity activity)
        {
            context.Activities.Add(activity);
            await context.SaveChangesAsync();
        }

        public async Task EditActivityAsync(Guid id, Activity activity)
        {
            var entity = await context.Activities.FindAsync(id);

            entity.Category = activity.Category;
            entity.City = activity.City;
            entity.Date = activity.Date;
            entity.Description = activity.Description;
            entity.Title = activity.Title;
            entity.Venue = activity.Venue;

            await context.SaveChangesAsync();
        }

        public async Task DeleteActivityAsync(Guid id)
        {
             var entity = await context.Activities.FindAsync(id);

             context.Activities.Remove(entity);
             await context.SaveChangesAsync();
        }
    }
}