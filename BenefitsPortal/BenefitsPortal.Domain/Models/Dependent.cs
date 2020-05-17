﻿using System;

namespace BenefitsPortal.Domain.Models
{
    public class Dependent
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name => $"{FirstName} {LastName}";
    }
}
