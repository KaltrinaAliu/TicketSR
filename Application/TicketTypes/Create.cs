using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.TicketTypes
{
    public class Create
    {
         public class Command : IRequest
        {
           public Guid Id { get; set; }
           public string Name { get; set; }
           public DateTime CreatedDate { get; set; }
           public DateTime UpdatedDate { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ticketContext _context;
            public Handler(ticketContext context)
            {
                _context = context;

            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
               var ticketTypes=new TicketType
               {
                    Id=request.Id,
                    Name=request.Name,
                    CreatedDate=request.CreatedDate,
                    UpdatedDate=request.UpdatedDate   
               };

               _context.TicketTypes.Add(ticketTypes);
               var success=await _context.SaveChangesAsync()>0;
               if(success) return Unit.Value;

               throw new Exception("Problem saving the data for the company");
            }
        }
    }
}