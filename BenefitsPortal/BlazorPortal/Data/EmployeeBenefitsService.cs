using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Formatting;

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

        public Task<EmployeeBenefits[]> GetEmployeeBenefitstAsync()
        {
            var rng = new Random();
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57674/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync(""); 
            if(response.Result.IsSuccessStatusCode)
            {
                var data = response.Result.Content.ReadAsAsync<EmployeeBenefits>();
            }
            else
            {

            }

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
    }
}
