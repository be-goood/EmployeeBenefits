using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BenefitsApiGateway.Domain.Interfaces;
using BenefitsApiGateway.Domain.Models;

namespace BenefitsApiGateway.Services
{
    public class DependentRepository : IDependentRepository
    {
        private HttpClient _client = null;

        public DependentRepository(HttpClient client, string dependetServiceUri)
        {
            client.BaseAddress = new Uri(dependetServiceUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client = client;
        }

        public async Task<List<Dependent>> GetAllEmployeeDependentsAsync(Guid emploeeId)
        {
            try
            {
                var response = await _client.GetAsync($"api/Dependents?employeeId={emploeeId}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<List<Dependent>>();
                    return data;
                }
                else
                {
                    // add log
                    // wrap response in a generic service response
                    return new List<Dependent>();
                }
            }
            catch (Exception ex)
            {
                // add log
                throw;
            }
        }
        public async Task AddDependentAsync(AddDependentModel newDependent)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("api/Dependents/AddDependet", newDependent);
                if (response.IsSuccessStatusCode)
                {
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                // add log
                throw;
            }
        }

        public async Task UpdateDependentAsync(UpdateDependentModel dependentToUpdate)
        {
            try
            {
                var response = await _client.PutAsJsonAsync("api/Dependents/UpdateDependet", dependentToUpdate);
                if (response.IsSuccessStatusCode)
                {
                }
                else
                {
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
