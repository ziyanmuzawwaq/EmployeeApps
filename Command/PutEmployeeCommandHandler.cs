using CSharpFunctionalExtensions;
using EmployeeApps.Api.Helper;
using EmployeeApps.Api.Models;
using EmployeeApps.Api.Repositories;
using MediatR;
using System.Diagnostics.Contracts;

namespace EmployeeApps.Api.Command
{
    public class PutEmployeeCommandHandler : IRequestHandler<PutEmployeeCommand, Result<ApiResponse>>
    {
        private readonly ILogger<PutEmployeeCommandHandler> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public PutEmployeeCommandHandler(
            ILogger<PutEmployeeCommandHandler> logger,
            IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        public async Task<Result<ApiResponse>> Handle(PutEmployeeCommand request, CancellationToken cancellationToken)
        {
            Contract.Assert(request != null);
            _logger.LogTrace("Executing handler for request : {request}", nameof(PutEmployeeCommand));

            try
            {
                var data = await _employeeRepository.Put(request.Request, cancellationToken);

                if (data is null) return ResponseHelper.Failed($"Update employee {request.Request.Id} failed");

                return ResponseHelper.Success(data);
            }
            catch (Exception ex)
            {
                return ResponseHelper.Failed(ex.Message);
            }
        }
    }
}
