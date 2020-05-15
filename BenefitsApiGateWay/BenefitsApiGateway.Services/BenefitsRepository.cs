using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BenefitsApiGateway.Domain.Interfaces;
using BenefitsApiGateway.Domain.Models;

namespace BenefitsApiGateway.Services
{
    public class BenefitsRepository : IBenefitsRepository
    {
        private HttpClient _client = null;

        public BenefitsRepository(HttpClient client, string medicalBenefitsServiceUri)
        {
            client.BaseAddress = new Uri(medicalBenefitsServiceUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client = client;
        }

        public async Task<List<EmpDependetsBenefitDetails>> GetEmployeeMedBenefitsAsync(List<InputEmployee> employees)
        {
            try
            {
                var response = await _client.PostAsJsonAsync($"api/MedicalBenefitsCost", employees);
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
    }
}
