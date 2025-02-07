namespace Application.Activities
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Core;
    using AutoMapper;
    using Domain;
    using FluentValidation;
    using MediatR;
    using Persistence;

    public class Edit
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
            private readonly IMapper mapper;

            public Handler(ReactivitiesContext _context, IMapper _mapper)
            {
                context = _context;
                mapper = _mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync(request.Activity.Id);

                mapper.Map(request.Activity, activity);

                var result = await context.SaveChangesAsync();

                return result > 0 ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to update activity");
            }
        }

    }
}