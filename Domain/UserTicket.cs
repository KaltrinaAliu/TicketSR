using System;
using System.Collections.Generic;

namespace Domain
{
    public class UserTicket
    {
        public string UserId { get; set; }
        public Guid TicketId { get; set; }

        public AppUser User { get; set; }
        public Ticket Ticket { get; set; }
        public DateTime DateJoined { get; set; }
        public bool IsHost { get; set; }
    }
}