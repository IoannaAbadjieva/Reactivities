using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<Activity[]> { }

        public class Handler : IRequestHandler<Query, Activity[]>
        {
            private readonly ReactivitiesContext context;
            public Handler(ReactivitiesContext _context)
            {
                context = _context;
            }
            public async Task<Activity[]> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.Activities.ToArrayAsync();
            }
        }
    }
}