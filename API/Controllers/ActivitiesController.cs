namespace API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Core;
    using Infrastructure.Data.Models;
    using Microsoft.AspNetCore.Mvc;

    public class ActivitiesController : BaseApiController
    {
        private readonly ActivityService actvitiesService;


        public ActivitiesController(ActivityService _actvitiesService)
        {
            actvitiesService = _actvitiesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivities()
        {
            return await actvitiesService.GetActivities();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await actvitiesService.GetActivity(id);
        }

    }
}