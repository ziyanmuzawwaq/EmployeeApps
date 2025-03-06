using Microsoft.Extensions.Caching.Memory;

namespace EmployeeApps.Api.Repositories
{
    public class DepartmentRepository : BaseRepository, IDepartmentRepository
    {
        public SqlDBContext _context;

        public DepartmentRepository(IConfiguration configuration, SqlDBContext context, IMemoryCache memoryCache)
            : base(configuration, memoryCache)
        {
            _context = context;
        }

        public bool Check(int id)
        {
            try
            {
                return _context.Departments.Any(x => x.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
