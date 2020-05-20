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

        public async Task<Dependent> GetDependentAsync(Guid dependentId)
        {
            var response = await _client.GetAsync($"api/EmployeeBenefits/GetDependent?dependentId={dependentId}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsAsync<Dependent>();
                return data;
            }
            else
            {
                // add log
                // wrap response in a generic service response
                return new Dependent();
            }
        }

        public async Task AddDependentAsync(AddDependentModel newDependent)
        {
            var response = await _client.PostAsJsonAsync("api/EmployeeBenefits/AddDependet", newDependent);
            if (!response.IsSuccessStatusCode)
            {
                //todo: log errors
            }
        }

        public async Task UpdateDependentAsync(UpdateDependentModel dependentToUpdate)
        {
            var response = await _client.PutAsJsonAsync("api/EmployeeBenefits/UpdateDependet", dependentToUpdate);
            if (!response.IsSuccessStatusCode)
            {
                //todo: log errors
            }
        }

    }
}
