﻿using BenefitsApiGateway.Domain.Configurations;
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

    }
}