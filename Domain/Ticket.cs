using System;

namespace Domain
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Issue { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ClosedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}