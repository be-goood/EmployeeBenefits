using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BenefitsApiGateway.Domain.Interfaces;
using BenefitsApiGateway.Domain.Models;

namespace BenefitsApiGateway.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private HttpClient _client = null;

        public EmployeeRepository(HttpClient client, string employeeServiceUri)
        {
            if(client != null && client.BaseAddress == null)
            {
                client.BaseAddress = new Uri(employeeServiceUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            _client = client;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            try
            {
                var response = await _client.GetAsync("api/Employee/GetAllEmployees");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<List<Employee>>();
                    return data;
                }
                else
                {
                    // add log
                    // wrap response in a generic service response
                    return new List<Employee>();
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
