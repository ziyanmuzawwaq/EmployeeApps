using CSharpFunctionalExtensions;
using EmployeeApps.Api.Models;
using EmployeeApps.Api.Models.Requests;
using MediatR;

namespace EmployeeApps.Api.Command
{
    public class PutEmployeeCommand : IRequest<Result<ApiResponse>>
    {
        public PutEmployeeCommand(UpdateEmployeeRequest request)
        {
            Request = request;
        }

        public UpdateEmployeeRequest Request { get; set; }
    }
}
