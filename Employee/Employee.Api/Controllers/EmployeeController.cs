using System;
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

        public EmployeeController(IOptionsMonitor<ApiSettings> settings, IQuery<EmployeeEntity, Guid> getEmployeeAndCurrentSalaryQuery)
        {
            _settings = settings.CurrentValue;
            _getEmployeeAndCurrentSalaryQuery = getEmployeeAndCurrentSalaryQuery;
        }

        [HttpGet]
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
    }
}