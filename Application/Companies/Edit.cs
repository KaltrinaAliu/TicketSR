using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Companies
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public bool? IsActive { get; set; }
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
                var company = await _context.Companies.FindAsync(request.Id);
                if(company==null)
                    throw new Exception("Could not find company");
                    
                company.Name=request.Name??company.Name;
                company.Description=request.Description??company.Description;
                company.IsActive=request.IsActive??company.IsActive;
                company.CreatedDate=company.CreatedDate;
                company.UpdatedDate=request.UpdatedDate;


                var success=await _context.SaveChangesAsync()>0;
                if(success) return Unit.Value;
                throw new Exception("Problem editing the data");

            }
        }
    }
}