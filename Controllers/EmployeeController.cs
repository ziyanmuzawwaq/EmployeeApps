using EmployeeApps.Api.Command;
using EmployeeApps.Api.Models;
using EmployeeApps.Api.Models.Enum;
using EmployeeApps.Api.Models.Requests;
using EmployeeApps.Api.Query;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApps.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ValidationController<EmployeeController>
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMediator _mediator;

        public EmployeeController(
            IMediator mediator,
            IEnumerable<IValidator> validators,
            ILogger<EmployeeController> logger) : base(validators, logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("/api/employee/lazy")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> GetLazy()
        {
            try
            {
                _logger.LogInformation($"Start {nameof(EmployeeController)}-{nameof(GetLazy)}");

                var query = new GetEmployeeQuery(0, RequestType.Lazy, Models.Enum.GetType.Multiple);
                var response = await ValidateAndExecute(query, (q) => _mediator.Send(query)).ConfigureAwait(false);

                _logger.LogInformation($"End {nameof(EmployeeController)}-{nameof(GetLazy)}");

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(EmployeeController)}-{nameof(GetLazy)}");

                throw;
            }
        }

        [HttpGet("/api/employee/lazy/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> GetLazyById(int id)
        {
            try
            {
                _logger.LogInformation($"Start {nameof(EmployeeController)}-{nameof(GetLazyById)}");

                var query = new GetEmployeeQuery(id, RequestType.Lazy, Models.Enum.GetType.Single);
                var response = await ValidateAndExecute(query, (q) => _mediator.Send(query)).ConfigureAwait(false);

                _logger.LogInformation($"End {nameof(EmployeeController)}-{nameof(GetLazyById)}");

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(EmployeeController)}-{nameof(GetLazyById)}");

                throw;
            }
        }

        [HttpGet("/api/employee/eager")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> GetEager()
        {
            try
            {
                _logger.LogInformation($"Start {nameof(EmployeeController)}-{nameof(GetEager)}");

                var query = new GetEmployeeQuery(0, RequestType.Eager, Models.Enum.GetType.Multiple);
                var response = await ValidateAndExecute(query, (q) => _mediator.Send(query)).ConfigureAwait(false);

                _logger.LogInformation($"End {nameof(EmployeeController)}-{nameof(GetEager)}");

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(EmployeeController)}-{nameof(GetEager)}");

                throw;
            }
        }

        [HttpGet("/api/employee/eager/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> GetEagerById(int id)
        {
            try
            {
                _logger.LogInformation($"Start {nameof(EmployeeController)}-{nameof(GetEagerById)}");

                var query = new GetEmployeeQuery(id, RequestType.Eager, Models.Enum.GetType.Single);
                var response = await ValidateAndExecute(query, (q) => _mediator.Send(query)).ConfigureAwait(false);

                _logger.LogInformation($"End {nameof(EmployeeController)}-{nameof(GetEagerById)}");

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(EmployeeController)}-{nameof(GetEagerById)}");

                throw;
            }
        }

        [HttpPost("/api/employee/create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> Post(CreateEmployeeRequest request)
        {
            try
            {
                _logger.LogInformation($"Start {nameof(EmployeeController)}-{nameof(Post)}");

                var query = new PostEmployeeCommand(request);
                var response = await ValidateAndExecute(query, (q) => _mediator.Send(query)).ConfigureAwait(false);

                _logger.LogInformation($"End {nameof(EmployeeController)}-{nameof(Post)}");

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(EmployeeController)}-{nameof(Post)}");

                throw;
            }
        }

        [HttpPost("/api/employee/update")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> Put(UpdateEmployeeRequest request)
        {
            try
            {
                _logger.LogInformation($"Start {nameof(EmployeeController)}-{nameof(Put)}");

                var query = new PutEmployeeCommand(request);
                var response = await ValidateAndExecute(query, (q) => _mediator.Send(query)).ConfigureAwait(false);

                _logger.LogInformation($"End {nameof(EmployeeController)}-{nameof(Put)}");

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(EmployeeController)}-{nameof(Put)}");

                throw;
            }
        }

        [HttpPost("/api/employee/delete")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<ApiResponse>> Delete(int id)
        {
            try
            {
                _logger.LogInformation($"Start {nameof(EmployeeController)}-{nameof(Delete)}");

                var query = new DeleteEmployeeCommand(id);
                var response = await ValidateAndExecute(query, (q) => _mediator.Send(query)).ConfigureAwait(false);

                _logger.LogInformation($"End {nameof(EmployeeController)}-{nameof(Delete)}");

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in {nameof(EmployeeController)}-{nameof(Delete)}");

                throw;
            }
        }
    }
}
