namespace Application.Activities
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain;
    using MediatR;
    using Persistence;

    public class Create
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ReactivitiesContext context;

            public Handler(ReactivitiesContext _context)
            {
                context = _context;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                context.Activities.Add(request.Activity);

                await context.SaveChangesAsync();

            }
        }
    }
}