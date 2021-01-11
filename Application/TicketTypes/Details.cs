using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.TicketTypes
{
    public class Details
    {
          public class Query : IRequest<TicketType> 
          { 
              public Guid Id {get; set;}
          }

        public class Handler : IRequestHandler<Query, TicketType>
        {
            private readonly ticketContext _context;
            public Handler(ticketContext context)
            {
                _context = context;

            }
            public async Task<TicketType> Handle(Query request, CancellationToken cancellationToken)
            {
                var ticketType= await _context.TicketTypes.FindAsync(request.Id);
                return ticketType;
            }
        }
    }
}