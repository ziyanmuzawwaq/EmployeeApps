using CSharpFunctionalExtensions;
using EmployeeApps.Api.Models;
using EmployeeApps.Api.Models.Requests;
using MediatR;

namespace EmployeeApps.Api.Command
{
    public class DeleteEmployeeCommand : IRequest<Result<ApiResponse>>
    {
        public DeleteEmployeeCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
