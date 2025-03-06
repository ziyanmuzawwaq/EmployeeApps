using CSharpFunctionalExtensions;
using EmployeeApps.Api.Models;
using EmployeeApps.Api.Models.Enum;
using MediatR;

namespace EmployeeApps.Api.Query
{
    public class GetEmployeeQuery : IRequest<Result<ApiResponse>>
    {
        public GetEmployeeQuery(int id, RequestType requestType, GetType getType)
        {
            Id = id;
            RequestType = requestType;
            GetTypes = getType;
        }

        public int Id { get; set; }
        public RequestType RequestType { get; set; }
        public GetType GetTypes { get; set; }
    }
}
