using BenefitsPortal.Domain.Interfaces;
using BenefitsPortal.Domain.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BenefitsPortal.Services
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

        public async Task AddDependentAsync(AddDependentModel newDependent)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("api/EmployeeBenefits/AddDependet", newDependent);
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
                var response = await _client.PutAsJsonAsync("api/EmployeeBenefits/UpdateDependet", dependentToUpdate);
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
