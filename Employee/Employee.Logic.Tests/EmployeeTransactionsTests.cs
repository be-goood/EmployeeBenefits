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
        //[TestMethod]
        //public async Task GetEmployeeWithoutCurrentSalaryAsync_2Salaries_ReturnActiveSalary()
        //{
        //    // arrange
        //    var salaries = new List<EmployeeSalary>()
        //    {
        //        new EmployeeSalary() { StartDate = new DateTime(2019,1,1), EndDate = new DateTime(2019,12,1), YearlyWages = 125000 },
        //        new EmployeeSalary() { StartDate = new DateTime(2019,1,1), EndDate = null, YearlyWages = 150000 },
        //    };
        //    var employee = new EmployeeEntity() { FirstName = "Jorge", LastName = "Velazquez", Salary = salaries };


        //    var employeeId = Guid.Parse("1608CA7F-4BD6-4F8D-8C20-93F8637F1052");
        //    var mock = new Mock<IQuery<EmployeeEntity, Guid>>();
        //    mock.Setup(p => p.ExecuteQueryAsync(employeeId)).Returns(Task.FromResult(employee));

        //    // assert
        //    var result = await new EmployeeTransactions().GetEmployeeWithoutSalaryAsync(mock.Object, employeeId);

        //    // act
        //    Assert.AreEqual(150000, result.Salary.First().YearlyWages);
        //}
    }
}
