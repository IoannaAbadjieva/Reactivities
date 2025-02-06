namespace Application.Activities
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain;
    using MediatR;
    using Persistence;

    public class Details
    {
        public class Query : IRequest<Activity>
        {
            public Guid Id {get; set;}

        }

        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly ReactivitiesContext context;

            public Handler(ReactivitiesContext _context)
            {
                context = _context;
            }
            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                return await context.Activities.FindAsync(request.Id);
            }
        }

    }
}