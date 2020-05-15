using System;

namespace Employee.Domain.Entities
{
    public class Status
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
    }
}
