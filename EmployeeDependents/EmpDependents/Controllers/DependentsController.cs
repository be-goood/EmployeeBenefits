using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmpDependents.Domain.Entities;
using EmpDependents.Domain.Interfaces;
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
        private ICommandNoResult<Dependent> _addDependentCommand;
        private ICommandNoResult<Dependent> _updateDependentCommand;

        public DependentsController(IOptionsMonitor<ApiSettings> settings, IQuery<List<Dependent>, Guid> getEmployeeDependentsQuery,
            ICommandNoResult<Dependent> addDependentCommand, ICommandNoResult<Dependent> updateDependentCommand)
        {
            _settings = settings.CurrentValue;
            _getEmployeeDependentsQuery = getEmployeeDependentsQuery;
            _addDependentCommand = addDependentCommand;
            _updateDependentCommand = updateDependentCommand;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Dependent>), 200)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> GetEmployee(Guid employeeId)
        {
            List<Dependent> model;

            try
            {
                model = await _getEmployeeDependentsQuery.ExecuteQueryAsync(employeeId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok(model);
        }
    }
}