using System;

namespace Employee.Domain.Models
{
    public class UpdateEmplyoeeModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
