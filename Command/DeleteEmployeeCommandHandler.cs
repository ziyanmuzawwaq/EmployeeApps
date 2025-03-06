using CSharpFunctionalExtensions;
using EmployeeApps.Api.Helper;
using EmployeeApps.Api.Models;
using EmployeeApps.Api.Repositories;
using MediatR;
using System.Diagnostics.Contracts;

namespace EmployeeApps.Api.Command
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Result<ApiResponse>>
    {
        private readonly ILogger<DeleteEmployeeCommandHandler> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeCommandHandler(
            ILogger<DeleteEmployeeCommandHandler> logger,
            IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        public async Task<Result<ApiResponse>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            Contract.Assert(request != null);
            _logger.LogTrace("Executing handler for request : {request}", nameof(DeleteEmployeeCommand));

            try
            {
                var isSuccess = await _employeeRepository.Delete(request.Id, cancellationToken);

                if (!isSuccess) return ResponseHelper.Failed($"Employee {request.Id} not found!");

                return ResponseHelper.Success();
            }
            catch (Exception ex)
            {
                return ResponseHelper.Failed(ex.Message);
            }
        }
    }
}
