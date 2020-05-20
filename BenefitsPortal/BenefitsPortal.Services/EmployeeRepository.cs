using BenefitsPortal.Domain.Interfaces;
using BenefitsPortal.Domain.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BenefitsPortal.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private HttpClient _client = null;

        public EmployeeRepository(HttpClient client, string employeeServiceUri)
        {
            client.BaseAddress = new Uri(employeeServiceUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client = client;
        }

        public async Task<Employee> GetEmployeeWithDependentsAsync(Guid employeeId)
        {
            Employee employee;
            try
            {
                var response = await _client.GetAsync($"api/EmployeeBenefits/GetEmployeesWithDependents?employeeId={employeeId}");
                if (response.IsSuccessStatusCode)
                {
                    employee = await response.Content.ReadAsAsync<Employee>();
                }
                else
                {
                    return new Employee();
                }
            }
            catch (Exception ex)
            {
                // add log
                throw;
            }
            return employee;
        }

        public async Task AddEmployeesAsync(AddEmployeeModel newEmployee)
        {
            try
            {
                var response = await _client.PostAsJsonAsync("api/EmployeeBenefits/AddEmployee", newEmployee);
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

        public async Task UpdateEmployeesAsync(UpdateEmplyoeeModel employeeToUpdate)
        {
            try
            {
                var response = await _client.PutAsJsonAsync("api/EmployeeBenefits/UpdateEmployee", employeeToUpdate);
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
