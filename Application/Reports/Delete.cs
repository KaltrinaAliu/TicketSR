using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using MediatR;
using Persistence;

namespace Application.Tags
{
    public class Reports
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
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
                var report = await _context.Reports.FindAsync(request.Id);
                if (report == null)
                    throw new RestException(HttpStatusCode.NotFound, new { report = "Could not find" });

                _context.Remove(report);

                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;
                throw new Exception("Problem saving the data");
            }
        }
    }
}