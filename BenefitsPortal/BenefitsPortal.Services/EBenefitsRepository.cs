using BenefitsPortal.Domain.Interfaces;
using BenefitsPortal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BenefitsPortal.Services
{
    public class EBenefitsRepository : IEBenefitsRepository
    {
        private HttpClient _client = null;
        public EBenefitsRepository(HttpClient client, string apiGatewayBaseServiceUri)
        {
            client.BaseAddress = new Uri(apiGatewayBaseServiceUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client = client;
        }

        private static readonly string[] Providers = new[]
        {
            "UnitedHealth Group", "Anthem ", "Centene ", "Humana ", "Cigna ", "WellCare Health Plans", "Molina Healthcare"
        };
        
        public async Task<List<EmpDependetsBenefitDetails>> GetEmployeeBenefitstTestAsync()
        {

            try
            {
                var response = await _client.GetAsync("api/EmployeeBenefits/GetAllEmployees");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<List<EmpDependetsBenefitDetails>>();
                    return data;
                }
                else
                {
                    // add log
                    // wrap response in a generic service response
                    return new List<EmpDependetsBenefitDetails>();
                }
            }
            catch (Exception ex)
            {
                // add log
                throw;
            }
        }

        public async Task<List<EmployeeBenefits>> GetEmployeeBenefitstAsync()
        {
            //var data = await GetEmployeeBenefitstTestAsync();
            return await GetEmployeeBenefitsTestAsync();
            //try
            //{
            //    var response = await _client.GetAsync("api/EmployeeBenefits/GetAllEmployees");
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var data = await response.Content.ReadAsAsync<List<EmployeeBenefits>>();
            //        return data;
            //    }
            //    else
            //    {
            //        // add log
            //        // wrap response in a generic service response
            //        return new List<EmployeeBenefits>();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // add log
            //    throw;
            //}
        }

        public Task<List<EmployeeBenefits>> GetEmployeeBenefitsTestAsync()
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new EmployeeBenefits
            {
                EmployeeName = "Jorge Velazquez",
                BenefitPlan = Providers[rng.Next(Providers.Length)],
                CoverageBeginDate = DateTime.Now,
                DeducationBeginDate = DateTime.Now,
                Coverage = "Family",
                CalculatedCoverage = 1000m,
                Dependents = "Ivy Velazquez Daphne Velazquez",
                Beneficiaries = "Heather Velazquez",
                SemiMonthlyEmployeeCost = 100m,
                SemiMonthlyEmployerContributions = 700m,
            }).ToList());
        }

    }
}
