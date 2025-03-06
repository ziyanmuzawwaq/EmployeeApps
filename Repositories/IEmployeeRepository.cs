using EmployeeApps.Api.Models.Entities;
using EmployeeApps.Api.Models.Enum;
using EmployeeApps.Api.Models.Requests;

namespace EmployeeApps.Api.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee?> Get(int id, RequestType requestType, CancellationToken cancellationToken);
        IEnumerable<Employee>? GetAll(int id, RequestType requestType);
        Task<Employee> Post(CreateEmployeeRequest request, CancellationToken cancellationToken);
        Task<Employee?> Put(UpdateEmployeeRequest request, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
    }
}
