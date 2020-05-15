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

        public EmployeeBenefitsController(IOptionsMonitor<ApiSettings> settings, IEmployeeRepository employeeRepository)
        {
            _settings = settings.CurrentValue;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Route("GetAllEmployees")]
        [ProducesResponseType(typeof(List<EmpDependetsBenefitDetails>), 200)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> GetAllEmployees()
        {
            List<EmpDependetsBenefitDetails> results;

            try
            {
                results = await new BenefitsOrchestration().GetEmployeeWithCurrentSalaryAsync(_employeeRepository);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok(results);
        }

    }
}