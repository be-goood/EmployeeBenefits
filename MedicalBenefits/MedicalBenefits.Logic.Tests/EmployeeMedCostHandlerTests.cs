using MedicalBenefits.Domain.Entities;
using MedicalBenefits.Domain.Interfaces;
using MedicalBenefits.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalBenefits.Logic.Tests
{
    [TestClass]
    public class EmployeeMedCostHandlerTests
    {
        [TestMethod]
        public async Task ExecuteAsync_2EmpWith2Depndents_ValidCostsAndDiscounts()
        {

            // arrange
            var employeeMedCostHandler = new EmployeeMedCostHandler();
            var p = new Parameters();
            var costRule = new CostRule() { BaseEmployeeCost = 1000, BaseDependentCost = 500, DiscountPercentage = 0.1m };
            var mock = new Mock<IQueryNoParam<CostRule>>();
            mock.Setup(s => s.ExecuteQueryAsync()).Returns(Task.FromResult(costRule));
            p.GetEmployeeCostRulesQuery = mock.Object;

            var inputDependents1 = new List<InputDependent>()
            {
                new InputDependent() { Id = Guid.Parse("D9AD13BD-4ADD-4E56-9C88-08D7E377ACA6"), Name = "Heather Velazquez" },
                new InputDependent() { Id = Guid.Parse("79676D54-7A8B-4F3C-8A90-1D0E27F9DD71"), Name = "Daphne Velazquez" },
            };
            var inputDependents2 = new List<InputDependent>()
            {
                new InputDependent() { Id = Guid.Parse("D9AD13BD-4ADD-4E56-9C88-08D7E377ACA6"), Name = "Heather Velazquez" },
                new InputDependent() { Id = Guid.Parse("79676D54-7A8B-4F3C-8A90-1D0E27F9DD71"), Name = "Daphne Velazquez" },
            };

            var inputEmployees = new List<InputEmployee>()
            {
                new InputEmployee(){ Id = Guid.Parse("48694223-E058-47D4-9886-2374A460AE4B"), Name = "Alex Doe", InputDependents = inputDependents1 },
                new InputEmployee(){ Id = Guid.Parse("D97C9609-5A16-48E0-A346-A7141D638E9D"), Name = "Jorge Velazquez", InputDependents = inputDependents2 },
            };

            p.InputEmployees = inputEmployees;

            // act
            await employeeMedCostHandler.ExecuteAsync(p);

            // assert
            Assert.AreEqual(1000, p.Employees[0].BenefitsCost);
            Assert.AreEqual(100, p.Employees[0].BenefitDiscount);
            Assert.AreEqual(1900, p.Employees[0].TotalBenefitsCost);
            Assert.AreEqual(100, p.Employees[0].TotalBenefitsDiscount);

            Assert.AreEqual(1000, p.Employees[1].BenefitsCost);
            Assert.AreEqual(0, p.Employees[1].BenefitDiscount);
            Assert.AreEqual(2000, p.Employees[1].TotalBenefitsCost);
            Assert.AreEqual(0, p.Employees[1].TotalBenefitsDiscount);
        }
    }
}
