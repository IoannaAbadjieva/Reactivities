using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        private readonly ReactivitiesContext context;
        public ActivitiesController(ReactivitiesContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivities()
        {
            return await context.Activities.ToArrayAsync();
        }

        [HttpGet("{id}")]
        public async Task<Activity> GetActivity(Guid id)
        {
            return await context.Activities.FindAsync(id);
        }

    }
}