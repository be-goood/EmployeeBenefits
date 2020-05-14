using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalBenefits.Domain.Entities
{
    [Table("CostRules")]
    public class CostRule
    {
        [Key]
        public Guid Id { get; set; }
        public decimal BaseEmployeeCost { get; set; }
        public decimal BaseDependentCost { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        //public string Name { get; set; }
        //public string ClassName { get; set; }
        //public string Description { get; set; }
        //public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }

    }
}
