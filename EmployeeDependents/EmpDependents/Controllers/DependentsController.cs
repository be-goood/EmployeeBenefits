using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmpDependents.Domain.Models.Entities;
using EmpDependents.Domain.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace EmpDependents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DependentsController : ControllerBase
    {
        private ApiSettings _settings;
        private IQuery<List<Dependent>, Guid> _getEmployeeDependentsQuery;

        public DependentsController(IOptionsMonitor<ApiSettings> settings, IQuery<List<Dependent>, Guid> getEmployeeDependentsQuery)
        {
            _settings = settings.CurrentValue;
            _getEmployeeDependentsQuery = getEmployeeDependentsQuery;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Dependent>), 200)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> GetEmployee(Guid employeeId)
        {
            List<Dependent> model;

            try
            {
                model = await _getEmployeeDependentsQuery.ExecuteQueryAsync(employeeId).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok(model);
        }
    }
}