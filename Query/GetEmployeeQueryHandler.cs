using CSharpFunctionalExtensions;
using EmployeeApps.Api.Helper;
using EmployeeApps.Api.Models;
using EmployeeApps.Api.Repositories;
using MediatR;
using System.Diagnostics.Contracts;

namespace EmployeeApps.Api.Query
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, Result<ApiResponse>>
    {
        private readonly ILogger<GetEmployeeQueryHandler> _logger;
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeQueryHandler(
            ILogger<GetEmployeeQueryHandler> logger,
            IEmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        public async Task<Result<ApiResponse>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            Contract.Assert(request != null);
            _logger.LogTrace("Executing handler for request : {request}", nameof(GetEmployeeQuery));

            try
            {
                switch (request.GetTypes)
                {
                    case Models.Enum.GetType.Single:

                        var data = await _employeeRepository.Get(request.Id, request.RequestType, cancellationToken);

                        if (data is null) return ResponseHelper.Failed("Data not found!");

                        return ResponseHelper.Success(data);

                    case Models.Enum.GetType.Multiple:

                        var dataAll = _employeeRepository.GetAll(request.Id, request.RequestType);

                        if (dataAll is null) return ResponseHelper.Failed("Data not found!");

                        return ResponseHelper.Success(dataAll);
                }

                return ResponseHelper.Failed("GetType not found!");
            }
            catch (Exception ex)
            {
                return ResponseHelper.Failed(ex.Message);
            }
        }
    }
}
