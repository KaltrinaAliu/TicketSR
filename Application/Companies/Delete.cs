using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Companies
{
    public class Delete
    {
                public class Command : IRequest
                {
                  public Guid Id {get; set;}
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
                       var company=await _context.Companies.FindAsync(request.Id);
                       if(company==null)
                       throw new Exception("Could not find company");

                        _context.Remove(company);

                       var success=await _context.SaveChangesAsync()>0;
                       if(success) return Unit.Value;
                       throw new Exception("Problem saving the data");
                    }
                }
    }
}