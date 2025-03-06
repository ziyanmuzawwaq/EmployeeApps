using CSharpFunctionalExtensions;
using EmployeeApps.Api.Models;
using EmployeeApps.Api.Models.Requests;
using MediatR;

namespace EmployeeApps.Api.Command
{
    public class PostEmployeeCommand : IRequest<Result<ApiResponse>>
    {
        public PostEmployeeCommand(CreateEmployeeRequest request)
        {
            Request = request;
        }

        public CreateEmployeeRequest Request { get; set; }
    }
}
