using System;
using System.Collections.Generic;

namespace Employee.Domain.Models.Entities
{
    public class EmployeeEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public Guid StatusId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        //public virtual Status Status { get; set; }
        public virtual List<EmployeeSalary> Salary { get; set; }
    }
}
