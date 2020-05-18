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
        

        public async Task<List<EmployeeBenefits>> GetEmployeeBenefitstAsync()
        {
            return await GetEmployeeBenefitsTestAsync();
            //try
            //{
            //    var response = await _client.GetAsync("api/EmployeeBenefits/GetAllEmployees");
            //    if (response.IsSuccessStatusCode)
            //    {
            //        var data = await response.Content.ReadAsAsync<List<EmpDependetsBenefitDetails>>();
            //        return MapResults(data);
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

        private List<EmployeeBenefits> MapResults(List<EmpDependetsBenefitDetails> data)
        {
            var rng = new Random();
            var results = new List<EmployeeBenefits>();
            foreach(var item in data)
            {
                var temp = new EmployeeBenefits();
                temp.EmployeeName = item.Name;
                temp.BenefitPlan = Providers[rng.Next(Providers.Length)];
                temp.CoverageBeginDate = DateTime.Now;
                temp.DeducationBeginDate = DateTime.Now;
                temp.Coverage = "Family";
                temp.CalculatedCoverage = 1000m;
                //temp.Dependents = item.Dependents.Select(s => s.Name).ToList();
                var dNames = item.Dependents.Select(s => s.Name).ToList();
                temp.Dependents = string.Join("   ",dNames);
                temp.Beneficiaries = "";
                temp.SemiMonthlyEmployeeCost = item.TotalBenefitsCost;
                temp.SemiMonthlyEmployerContributions = item.TotalBenefitsDiscount;

                results.Add(temp);
            }
            return results;
        }

        public async Task<List<MedicalBenefit>> GetEmployeeMedBenefitsAsync()
        {
            try
            {
                var response = await _client.GetAsync("api/EmployeeBenefits/GetAllEmployees");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<List<EmpDependetsBenefitDetails>>();
                    return MapBenefitResults(data);
                }
                else
                {
                    // add log
                    // wrap response in a generic service response
                    return new List<MedicalBenefit>();
                }
            }
            catch (Exception ex)
            {
                // add log
                throw;
            }
        }

        private List<MedicalBenefit> MapBenefitResults(List<EmpDependetsBenefitDetails> data)
        {
            var rng = new Random();
            var results = new List<MedicalBenefit>();
            foreach (var item in data)
            {
                var temp = new MedicalBenefit();
                temp.EmployeeId = item.Id;
                temp.EmployeeName = item.Name;
                var dNames = item.Dependents.Select(s => s.Name).ToList();
                temp.Dependents = string.Join(", ", dNames);
                temp.BaseEmployeeCost = item.TotalBenefitsDiscount + item.TotalBenefitsCost;
                temp.EmployeeDiscountAmount = item.TotalBenefitsDiscount;
                temp.TotalEmployeeCost = item.TotalBenefitsCost;

                results.Add(temp);
            }
            return results;
        }

        public Task<List<MedicalBenefit>> GetEmployeeMedBenefitsTestAsync()
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new MedicalBenefit
            {
                EmployeeId = Guid.NewGuid(),
                EmployeeName = "Jorge Velazquez",
                Dependents = "Ivy Velazquez, Daphne Velazquez",
                BaseEmployeeCost = 100m,
                EmployeeDiscountAmount = 700m,
                TotalEmployeeCost = 700m,
            }).ToList());
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
                    //Dependents = new List<string>() { "Ivy Velazquez", "Daphne Velazquez" },
                    Dependents = "Ivy Velazquez   Daphne Velazquez",
                    Beneficiaries = "Heather Velazquez",
                    SemiMonthlyEmployeeCost = 100m,
                    SemiMonthlyEmployerContributions = 700m,
                }).ToList()); ;
            }

    }
}
