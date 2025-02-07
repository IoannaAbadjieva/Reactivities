namespace Application.Activities
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Core;
    using MediatR;
    using Persistence;

    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly ReactivitiesContext context;

            public Handler(ReactivitiesContext _context)
            {
                context = _context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync(request.Id);

                if (activity == null) return null;

                context.Remove(activity);
                var result = await context.SaveChangesAsync();

                return result > 0 ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to delete activity");
            }
        }
    }
}