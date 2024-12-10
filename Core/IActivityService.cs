using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data.Models;

namespace Core
{
    public interface IActivityService
    {
        Task<Activity[]> GetAllActivitiesAsync();
        Task<Activity?> GetActivityAsync(Guid id);
        Task AddActivityAsync(Activity activity);
        Task EditActivityAsync(Guid id, Activity activity);
        Task DeleteActivityAsync(Guid id);
    }
}