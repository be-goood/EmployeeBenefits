using EmpDependents.Domain.Entities;
using EmpDependents.Domain.Interfaces;
using EmpDependents.Domain.Models;
using System;
using System.Threading.Tasks;

namespace EmpDependents.Logic
{
    public class DependentTransactions
    {
        public async Task AddDependent(IAddCommandNoResult<Dependent> addEmployeeCommand, AddDependentModel dependentModel)
        {
            //  todo: apply error checking before executing command
            var now = DateTime.Now;
            var dependent = new Dependent();
            dependent.Id = Guid.NewGuid();
            dependent.EmployeeId = dependentModel.EmployeeId;
            dependent.FirstName = dependentModel.FirstName;
            dependent.LastName = dependentModel.LastName;
            dependent.Ssn = dependentModel.Ssn;
            dependent.Dob = dependentModel.Dob;
            dependent.CreatedOn = now;
            dependent.CreatedBy = string.Empty;
            dependent.UpdatedOn = now;
            dependent.UpdatedBy = string.Empty;
            await addEmployeeCommand.ExecuteAsync(dependent);
        }

        public async Task UpdateDependent(IUpdateCommandNoResult<Dependent> updateDependentCommand, IQuery<Dependent, Guid> getDependentQuery,
                            UpdateDependentModel dependentModel)
        {
            var dependentToUpdate = await getDependentQuery.ExecuteQueryAsync(dependentModel.Id);
            dependentToUpdate.FirstName = dependentModel.FirstName;
            dependentToUpdate.LastName = dependentModel.LastName;
            dependentToUpdate.Ssn = dependentModel.Ssn;
            dependentToUpdate.Dob = dependentModel.Dob;
            dependentToUpdate.UpdatedOn = DateTime.Now;

            //  todo: apply error checking before executing command
            await updateDependentCommand.ExecuteAsync(dependentToUpdate);
        }

    }
}
