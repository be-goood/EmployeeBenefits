using System;
using System.Collections.Generic;

namespace BenefitsApiGateway.Domain.Models
{
    public class InputEmployee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<InputDependent> InputDependents { get; set; } = new List<InputDependent>();
    }
}
