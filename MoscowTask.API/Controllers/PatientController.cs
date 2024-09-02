using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoscowTask.Contracts.PatientRequests.GetPatientById;
using MoscowTask.Contracts.PatientRequests.GetPatients;
using MoscowTask.Contracts.PatientRequests.PostPatient;
using MoscowTask.Contracts.PatientRequests.PutPatient;
using MoscowTask.Core.Requests.PatientRequests.DeletePatient;
using MoscowTask.Core.Requests.PatientRequests.GetPatientById;
using MoscowTask.Core.Requests.PatientRequests.GetPatients;
using MoscowTask.Core.Requests.PatientRequests.PostPatient;
using MoscowTask.Core.Requests.PatientRequests.PutPatient;

namespace MoscowTask.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    /// <summary>
    /// Создать сущность
    /// </summary>
    /// <param name="mediator">Медиатор CQRS</param>
    /// <param name="request">Запрос</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор созданной сущности</returns>
    [ProducesResponseType(type: typeof(PostPatientResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(type: typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<PostPatientResponse> CreateAsync(
        [FromServices] IMediator mediator,
        [FromBody] PostPatientRequest request,
        CancellationToken cancellationToken)
        => await mediator
            .Send(
                new PostPatientCommand
                {
                    Surname = request.Surname,
                    Name = request.Name,
                    Patronymic = request.Patronymic,
                    Address = request.Address,
                    Birthday = request.Birthday,
                    Gender = request.Gender,
                    PlotId = request.PlotId
                },
                cancellationToken);
    
    /// <summary>
    /// Получить список докторов
    /// </summary>
    /// <param name="mediator">Медиатор CQRS</param>
    /// <param name="request">Запрос</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список сущностей</returns>
    [HttpGet]
    [ProducesResponseType(type: typeof(GetPatientsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(type: typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<GetPatientsResponse> GetAsync(
        [FromServices] IMediator mediator,
        [FromQuery] GetPatientsRequest? request,
        CancellationToken cancellationToken)
        => await mediator.Send(
            request == null
                ? new GetPatientsQuery()
                : new GetPatientsQuery
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    OrderBy = request.OrderBy,
                    IsAscending = request.IsAscending
                }, cancellationToken);
    
    /// <summary>
    /// Получить доктора по идентификатору
    /// </summary>
    /// <param name="mediator">Медиатор CQRS</param>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Доктор</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(type: typeof(GetPatientByIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(type: typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<GetPatientByIdResponse> GetByIdAsync(
        [FromServices] IMediator mediator,
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
        => await mediator.Send(new GetPatientByIdQuery(id), cancellationToken);
    
    /// <summary>
    /// Обновить пациента
    /// </summary>
    /// <param name="mediator">Медиатор CQRS</param>
    /// <param name="id">Идентификатор врача</param>
    /// <param name="request">Запрос</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(type: typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task PutAsync(
        [FromServices] IMediator mediator,
        [FromRoute] Guid id,
        [FromBody] PutPatientRequest request,
        CancellationToken cancellationToken)
        => await mediator
            .Send(
                new PutPatientCommand(id)
                {
                    Surname = request.Surname,
                    Name = request.Name,
                    Patronymic = request.Patronymic,
                    Address = request.Address,
                    Birthday = request.Birthday,
                    Gender = request.Gender,
                    PlotId = request.PlotId
                },
                cancellationToken);
    
    /// <summary>
    /// Удалить пациента
    /// </summary>
    /// <param name="mediator">Медиатор CQRS</param>
    /// <param name="id">Идентификатор врача</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(type: typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task DeleteAsync(
        [FromServices] IMediator mediator,
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
        => await mediator.Send(new DeletePatientCommand(id), cancellationToken);
}