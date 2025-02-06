namespace Application.Activities
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Persistence;

    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
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
                var activity = await context.Activities.FindAsync(request.Id);

                context.Remove(activity);
                await context.SaveChangesAsync();
            }
        }
    }
}