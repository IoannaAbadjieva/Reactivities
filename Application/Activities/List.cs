using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<Result<Activity[]>> { }

        public class Handler : IRequestHandler<Query, Result<Activity[]>>
        {
            private readonly ReactivitiesContext context;
            public Handler(ReactivitiesContext _context)
            {
                context = _context;
            }
            public async Task<Result<Activity[]>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<Activity[]>.Success(await context.Activities.ToArrayAsync());
            }
        }
    }
}