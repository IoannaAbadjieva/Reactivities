namespace Application.Activities
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Core;
    using Domain;
    using FluentValidation;
    using MediatR;
    using Persistence;

    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Activity Activity { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Activity).SetValidator(new ActivityValidator());
            }
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
                context.Activities.Add(request.Activity);

                var result = await context.SaveChangesAsync() ;

                return result > 0 ? Result<Unit>.Success(Unit.Value):Result<Unit>.Failure("Failed to create activity");

            }
        }
    }
}