using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public EmployeeController(IOptionsMonitor<ApiSettings> settings, IQuery<EmployeeEntity, Guid> getEmployeeAndCurrentSalaryQuery, IQueryNoParam<List<EmployeeEntity>> getAllEmployeesAndSalariesQuery)
        {
            _settings = settings.CurrentValue;
            _getEmployeeAndCurrentSalaryQuery = getEmployeeAndCurrentSalaryQuery;
            _getAllEmployeesAndSalariesQuery = getAllEmployeesAndSalariesQuery;
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
        public async Task<IActionResult> GetAllEmployees(Guid employeeId)
        {
            List<EmployeeEntity> results;

            try
            {
                results = await new EmployeeTransactions().GetAllEmployeesWithCurrentSalariesAsync(_getAllEmployeesAndSalariesQuery).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok(results);
        }
    }
}