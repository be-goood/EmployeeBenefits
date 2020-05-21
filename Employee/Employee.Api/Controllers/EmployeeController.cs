using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmpDependents.Domain.Interfaces;
using Employee.Domain.Configuration;
using Employee.Domain.Entities;
using Employee.Domain.Interfaces;
using Employee.Domain.Models;
using Employee.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Employee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private ApiSettings _settings;
        private IQuery<EmployeeEntity, Guid> _getEmployeeAndCurrentSalaryQuery;
        private IQueryNoParam<List<EmployeeEntity>> _getAllEmployeesAndSalariesQuery;
        private IAddCommandNoResult<EmployeeEntity> _addEmployeeCommand;
        private IUpdateCommandNoResult<EmployeeEntity> _updateEmployeeCommand;

        public EmployeeController(IOptionsMonitor<ApiSettings> settings, IQuery<EmployeeEntity, Guid> getEmployeeAndCurrentSalaryQuery, IQueryNoParam<List<EmployeeEntity>> getAllEmployeesAndSalariesQuery,
            IAddCommandNoResult<EmployeeEntity> addEmployeeCommand, IUpdateCommandNoResult<EmployeeEntity> updateEmployeeCommand)
        {
            _settings = settings.CurrentValue;
            _getEmployeeAndCurrentSalaryQuery = getEmployeeAndCurrentSalaryQuery;
            _getAllEmployeesAndSalariesQuery = getAllEmployeesAndSalariesQuery;
            _addEmployeeCommand = addEmployeeCommand;
            _updateEmployeeCommand = updateEmployeeCommand;
        }

        [HttpGet]
        [Route("GetEmployee")]
        [ProducesResponseType(typeof(EmployNoSalaryModel), 200)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> GetEmployee(Guid employeeId)
        {
            EmployNoSalaryModel model;

            try
            {
                model = await new EmployeeTransactions().GetEmployeeWithoutSalaryAsync(_getEmployeeAndCurrentSalaryQuery, employeeId).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok(model);
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        [ProducesResponseType(typeof(List<EmployeeEntity>), 200)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> GetAllEmployees()
        {
            List<EmployeeEntity> results;

            try
            {
                results = await new EmployeeTransactions().GetAllEmployeesWithCurrentSalariesAsync(_getAllEmployeesAndSalariesQuery);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok(results);
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee(AddEmployeeModel employee)
        {
            try
            {
                await new EmployeeTransactions().AddEmployee(_addEmployeeCommand, employee).ConfigureAwait(false); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok();
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee(UpdateEmplyoeeModel employee)
        {
            try
            {
                await new EmployeeTransactions().UpdateEmployee(_updateEmployeeCommand, _getEmployeeAndCurrentSalaryQuery, employee).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok();
        }
    }
}