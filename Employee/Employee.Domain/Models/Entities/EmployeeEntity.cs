using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Domain.Models.Entities
{
    [Table("Employees")]
    public class EmployeeEntity
    {
        [Key]
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
