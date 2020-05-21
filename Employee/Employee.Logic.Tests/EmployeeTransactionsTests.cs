using Employee.Domain.Entities;
using Employee.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Logic.Tests
{
    [TestClass]
    public class EmployeeTransactionsTests
    {
        [TestMethod]
        public async Task GetAllEmployeesWithCurrentSalariesAsync_MoreThan1Salary_ReturnCurrentSalary()
        {
            // Arrange
            var salaries = new List<EmployeeSalary>()
            {
                new EmployeeSalary() { StartDate = new DateTime(2019,1,1), EndDate = new DateTime(2019,12,1), YearlyWages = 125000 },
                new EmployeeSalary() { StartDate = new DateTime(2019,1,1), EndDate = null, YearlyWages = 52000 },
            };
            var employee = new EmployeeEntity() { FirstName = "Jorge", LastName = "Velazquez", Salary = salaries };
            var employees = new List<EmployeeEntity>() { employee };

            var employeeId = Guid.Parse("1608CA7F-4BD6-4F8D-8C20-93F8637F1052");
            var mock = new Mock<IQueryNoParam<List<EmployeeEntity>>>();
            mock.Setup(p => p.ExecuteQueryAsync()).Returns(Task.FromResult(employees));

            // Assert
            var result = await new EmployeeTransactions().GetAllEmployeesWithCurrentSalariesAsync(mock.Object);

            // Act
            Assert.IsNull(result.First().Salary.First().EndDate);
            Assert.AreEqual(52000, result.First().Salary.First().YearlyWages);
        }
    }
}
