using System;

namespace Domain
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Normalized { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}