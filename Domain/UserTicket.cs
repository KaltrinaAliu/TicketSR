using System;
using System.Collections.Generic;

namespace Domain
{
    public class UserTicket
    {
        public string UserId { get; set; }
        public Guid TicketId { get; set; }

        public virtual ICollection<AppUser> User { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
    }
}