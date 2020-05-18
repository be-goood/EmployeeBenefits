using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmpDependents.Domain.Interfaces;
using Employee.Domain.Configuration;
using Employee.Domain.Entities;
using Employee.Domain.Interfaces;
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
        private ICommandNoResult<EmployeeEntity> _addEmployeeCommand;
        private ICommandNoResult<EmployeeEntity> _updateEmployeeCommand;

        public EmployeeController(IOptionsMonitor<ApiSettings> settings, IQuery<EmployeeEntity, Guid> getEmployeeAndCurrentSalaryQuery, IQueryNoParam<List<EmployeeEntity>> getAllEmployeesAndSalariesQuery,
            ICommandNoResult<EmployeeEntity> addEmployeeCommand, ICommandNoResult<EmployeeEntity> updateEmployeeCommand)
        {
            _settings = settings.CurrentValue;
            _getEmployeeAndCurrentSalaryQuery = getEmployeeAndCurrentSalaryQuery;
            _getAllEmployeesAndSalariesQuery = getAllEmployeesAndSalariesQuery;
            _addEmployeeCommand = addEmployeeCommand;
            _updateEmployeeCommand = updateEmployeeCommand;
        }

        [HttpGet]
        [Route("GetEmployee")]
        [ProducesResponseType(typeof(EmployeeEntity), 200)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> GetEmployee(Guid employeeId)
        {
            EmployeeEntity model;

            try
            {
                model = await new EmployeeTransactions().GetEmployeeWithCurrentSalaryAsync(_getEmployeeAndCurrentSalaryQuery, employeeId).ConfigureAwait(false);
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
    }
}