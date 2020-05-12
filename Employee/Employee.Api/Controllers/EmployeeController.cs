using System;
using System.Threading.Tasks;
using Employee.Domain.Models.Configuration;
using Employee.Domain.Models.Entities;
using Employee.Domain.Models.Interfaces;
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
                model = await _getEmployeeAndCurrentSalaryQuery.ExecuteQuery(employeeId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok(model);
        }
    }
}