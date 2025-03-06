using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using System.Data;

namespace EmployeeApps.Api.Repositories
{
    public class BaseRepository
    {
        private readonly IConfiguration configuration;
        protected readonly IMemoryCache MemoryCache;

        protected IDbConnection DbEmployee => new SqlConnection(configuration.GetValue<string>("Database:ConnectionStrings"));

        public BaseRepository(IConfiguration configuration, IMemoryCache memoryCache)
        {
            this.configuration = configuration;
            MemoryCache = memoryCache;
        }
    }
}
