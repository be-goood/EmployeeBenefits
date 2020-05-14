using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedicalBenefits.Domain.Configuration;
using MedicalBenefits.Domain.Entities;
using MedicalBenefits.Domain.Interfaces;
using MedicalBenefits.Domain.Models;
using MedicalBenefits.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MedicalBenefits.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalBenefitsCostController : ControllerBase
    {
        private ApiSettings _settings;
        private IQueryNoParam<CostRule> _getEmployeeCostRulesQuery;
        public MedicalBenefitsCostController(IOptionsMonitor<ApiSettings> settings, IQueryNoParam<CostRule> getEmployeeCostRulesQuery)
        {
            _settings = settings.CurrentValue;
            _getEmployeeCostRulesQuery = getEmployeeCostRulesQuery;
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> GetEmployeeAsync(List<InputEmployee> employees)
        {
            var p = new Parameters();
            try
            {
                p = new Parameters() { InputEmployees = employees, GetEmployeeCostRulesQuery = _getEmployeeCostRulesQuery };
                await new CostRules().CalculateCostAsync(p);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }

            return Ok(p.Employees);
        }
    }
}
