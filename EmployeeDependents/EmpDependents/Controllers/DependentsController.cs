using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmpDependents.Domain.Entities;
using EmpDependents.Domain.Interfaces;
using EmpDependents.Domain.Models;
using EmpDependents.Logic;
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
        private IAddCommandNoResult<Dependent> _addDependentCommand;
        private IUpdateCommandNoResult<Dependent> _updateDependentCommand;
        private IQuery<Dependent, Guid> _getEmployeeDependentQuery;

        public DependentsController(IOptionsMonitor<ApiSettings> settings, IQuery<List<Dependent>, Guid> getEmployeeDependentsQuery,
            IAddCommandNoResult<Dependent> addDependentCommand, IUpdateCommandNoResult<Dependent> updateDependentCommand, IQuery<Dependent, Guid> getEmployeeDependentQuery)
        {
            _settings = settings.CurrentValue;
            _getEmployeeDependentsQuery = getEmployeeDependentsQuery;
            _getEmployeeDependentQuery = getEmployeeDependentQuery;
            _addDependentCommand = addDependentCommand;
            _updateDependentCommand = updateDependentCommand;
        }

        [HttpGet]
        [Route("GetDependent")]
        [ProducesResponseType(typeof(Dependent), 200)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> GetDependent(Guid dependentId)
        {
            Dependent model;

            try
            {
                model = await _getEmployeeDependentQuery.ExecuteQueryAsync(dependentId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok(model);
        }

        [HttpGet]
        [Route("GetEmployeeDependents")]
        [ProducesResponseType(typeof(List<Dependent>), 200)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> GetEmployeeDependents(Guid employeeId)
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

        [HttpPost]
        [Route("AddDependet")]
        public async Task<IActionResult> AddDependet(AddDependentModel dependet)
        {
            try
            {
                await new DependentTransactions().AddDependentAsync(_addDependentCommand, dependet).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok();
        }

        [HttpPut]
        [Route("UpdateDependet")]
        public async Task<IActionResult> UpdateDependet(UpdateDependentModel dependent)
        {
            try
            {
                await new DependentTransactions().UpdateDependentAsync(_updateDependentCommand, _getEmployeeDependentQuery, dependent).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok();
        }

    }
}