using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BlazorPortal.Data
{
    public class EmployeeBenefitsService
    {
        private static readonly string[] Providers = new[]
        {
            "UnitedHealth Group", "Anthem ", "Centene ", "Humana ", "Cigna ", "WellCare Health Plans", "Molina Healthcare"
        };

        public Task<EmployeeBenefits[]> GetEmployeeBenefitsTestAsync()
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
            }).ToArray());
        }

        public async Task<List<EmployeeBenefits>> GetEmployeeBenefitstAsync()
        {
            var rng = new Random();
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57674/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<List<EmployeeBenefits>>();
                    return data;
                }
                else
                {
                    // add log
                    // wrap response in a generic service response
                    return new List<EmployeeBenefits>();
                }
            }
            catch (Exception ex)
            {
                // add log
                throw;
            }
        }
    }
}
