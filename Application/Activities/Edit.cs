namespace Application.Activities
{
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Domain;
    using MediatR;
    using Persistence;

    public class Edit
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ReactivitiesContext context;
            private readonly IMapper mapper;

            public Handler(ReactivitiesContext _context, IMapper _mapper)
            {
                context = _context;
                mapper = _mapper;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await context.Activities.FindAsync(request.Activity.Id);

                mapper.Map(request.Activity, activity);

                await context.SaveChangesAsync();
            }
        }

    }
}