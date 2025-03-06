using CSharpFunctionalExtensions;
using MediatR;
using System.Diagnostics.Contracts;
using EmployeeApps.Api.Models;
using EmployeeApps.Api.Repositories;
using EmployeeApps.Api.Helper;

namespace EmployeeApps.Api.Command
{
    public class PostEmployeeCommandHandler : IRequestHandler<PostEmployeeCommand, Result<ApiResponse>>
    {
        private readonly ILogger<PostEmployeeCommandHandler> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public PostEmployeeCommandHandler(
            ILogger<PostEmployeeCommandHandler> logger,
            IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<Result<ApiResponse>> Handle(PostEmployeeCommand request, CancellationToken cancellationToken)
        {
            Contract.Assert(request != null);
            _logger.LogTrace("Executing handler for request : {request}", nameof(PostEmployeeCommand));

            try
            {
                var isAnyDepartment = _departmentRepository.Check(request.Request.DepartmentId);

                if (!isAnyDepartment) return ResponseHelper.Failed($"Department {request.Request.DepartmentId} not found!");

                var data = await _employeeRepository.Post(request.Request, cancellationToken);

                return ResponseHelper.Success(data);
            }
            catch (Exception ex)
            {
                return ResponseHelper.Failed(ex.Message);
            }
        }
    }
}
