namespace API.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Core;
    using Infrastructure.Data.Models;
    using Microsoft.AspNetCore.Mvc;

    public class ActivitiesController : BaseApiController
    {
        private readonly ActivityService actvityService;


        public ActivitiesController(ActivityService _actvityService)
        {
            actvityService = _actvityService;
        }

        [HttpGet]
        public async Task<ActionResult<Activity[]>> GetActivities(CancellationToken cancellationToken)
        {
            return await actvityService.GetAllActivitiesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await actvityService.GetActivityAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Activity activity)
        {
            await actvityService.AddActivityAsync(activity);
            return Ok();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, Activity activity)
        {
            await actvityService.EditActivityAsync(id, activity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await actvityService.DeleteActivityAsync(id);
            return Ok();
        }

    }
}