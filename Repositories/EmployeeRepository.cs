using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;
using EmployeeApps.Api.Models.Requests;
using EmployeeApps.Api.Models.Entities;
using EmployeeApps.Api.Models.Enum;

namespace EmployeeApps.Api.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public SqlDBContext _context;

        public EmployeeRepository(IConfiguration configuration, SqlDBContext context, IMemoryCache memoryCache)
            : base(configuration, memoryCache)
        {
            _context = context;
        }

        public async Task<Employee?> Get(int id, RequestType requestType, CancellationToken cancellationToken)
        {
            try
            {
                if (requestType.Equals(RequestType.Lazy))
                {
                    return await _context.Employees.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
                }
                else if (requestType.Equals(RequestType.Eager))
                {
                    return await _context.Employees.Include(x => x.Department).ThenInclude(y => y!.Employees).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Employee>? GetAll(int id, RequestType requestType)
        {
            try
            {
                if (requestType.Equals(RequestType.Lazy))
                {
                    return _context.Employees.AsEnumerable();
                }
                else if (requestType.Equals(RequestType.Eager))
                {
                    return _context.Employees.Include(x => x.Department).AsEnumerable();
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Employee> Post(CreateEmployeeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Employee employee = new Employee
                {
                    Name = request.Name,
                    DepartmentId = request.DepartmentId
                };

                await _context.AddAsync(employee);
                await _context.SaveChangesAsync();

                return employee;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Employee?> Put(UpdateEmployeeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (employee == null) return null;

                employee.Name = string.IsNullOrWhiteSpace(request.Name) ? employee.Name : request.Name;
                employee.DepartmentId = request.DepartmentId == 0 ? employee.DepartmentId : request.DepartmentId;

                _context.Entry(employee).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return employee;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

                if (employee == null) return false;

                _context.Entry(employee).State = EntityState.Deleted;
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
