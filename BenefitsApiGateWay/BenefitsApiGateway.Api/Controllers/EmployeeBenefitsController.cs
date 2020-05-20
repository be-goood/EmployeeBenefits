using BenefitsApiGateway.Domain.Configurations;
using BenefitsApiGateway.Domain.Interfaces;
using BenefitsApiGateway.Domain.Models;
using BenefitsApiGateway.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenefitsApiGateway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeBenefitsController : ControllerBase
    {
        private ApiSettings _settings;
        private IEmployeeRepository _employeeRepository;
        private IDependentRepository _dependentRepository;
        private IBenefitsRepository _benefitsRepository;
        public EmployeeBenefitsController(IOptionsMonitor<ApiSettings> settings, IEmployeeRepository employeeRepository, IDependentRepository dependentRepository, IBenefitsRepository benefitsRepository)
        {
            _settings = settings.CurrentValue;
            _employeeRepository = employeeRepository;
            _dependentRepository = dependentRepository;
            _benefitsRepository = benefitsRepository;
        }

        [HttpGet]
        [Route("GetDependent")]
        [ProducesResponseType(typeof(Dependent), 200)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> GetDependent(Guid dependentId)
        {
            Dependent dependentDetails;

            try
            {
                dependentDetails = await new DependentOrchestration().GetDependentAsync(_dependentRepository, dependentId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok(dependentDetails);
        }

        [HttpGet]
        [Route("GetEmployeesWithDependents")]
        [ProducesResponseType(typeof(Employee), 200)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> GetEmployeesWithDependents(Guid employeeId)
        {
            Employee employeeDetails;

            try
            {
                employeeDetails = await new BenefitsOrchestration().GetEmployeeWithDependentsAsync(_employeeRepository, _dependentRepository, employeeId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok(employeeDetails);
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        [ProducesResponseType(typeof(List<EmpDependetsBenefitDetails>), 200)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> GetAllEmployeesBenefitDetails()
        {
            List<EmpDependetsBenefitDetails> results;

            try
            {
                results = await new BenefitsOrchestration().GetEmployeeWithCurrentSalaryAsync(_employeeRepository, _dependentRepository, _benefitsRepository);
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
                await new EmployeeOrchestration().AddEmployeeAsync(_employeeRepository, employee).ConfigureAwait(false);
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
                await new EmployeeOrchestration().UpdateEmployeeAsync(_employeeRepository, employee).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok();
        }

        [HttpPost]
        [Route("AddDependet")]
        public async Task<IActionResult> AddDependet(AddDependentModel dependet)
        {
            try
            {
                await new DependentOrchestration().AddDependetAsync(_dependentRepository, dependet).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok();
        }

        [HttpPut]
        [Route("UpdateDependet")]
        public async Task<IActionResult> UpdateDependetAsync(UpdateDependentModel dependent)
        {
            try
            {
                await new DependentOrchestration().UpdateDependetAsync(_dependentRepository, dependent).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok();
        }

    }
}