using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoscowTask.Contracts.DoctorsRequests.GetDoctorById;
using MoscowTask.Contracts.DoctorsRequests.GetDoctors;
using MoscowTask.Contracts.DoctorsRequests.PostDoctor;
using MoscowTask.Contracts.DoctorsRequests.PutDoctor;
using MoscowTask.Core.Requests.DoctorRequests.DeleteDoctor;
using MoscowTask.Core.Requests.DoctorRequests.GetDoctorById;
using MoscowTask.Core.Requests.DoctorRequests.GetDoctors;
using MoscowTask.Core.Requests.DoctorRequests.PostDoctor;
using MoscowTask.Core.Requests.DoctorRequests.PutDoctor;

namespace MoscowTask.API.Controllers;

/// <summary>
/// Контроллер по работе с врачами
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class DoctorController : ControllerBase
{
    /// <summary>
    /// Создать сущность
    /// </summary>
    /// <param name="mediator">Медиатор CQRS</param>
    /// <param name="request">Запрос</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор созданной сущности</returns>
    [ProducesResponseType(type: typeof(PostDoctorResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(type: typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<PostDoctorResponse> CreateAsync(
        [FromServices] IMediator mediator,
        [FromBody] PostDoctorRequest request,
        CancellationToken cancellationToken)
        => await mediator
            .Send(
                new PostDoctorCommand
                {
                    Surname = request.Surname,
                    Name = request.Name,
                    Patronymic = request.Patronymic,
                    OfficeId = request.OfficeId,
                    SpecializationId = request.SpecializationId,
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
    [ProducesResponseType(type: typeof(GetDoctorsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(type: typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<GetDoctorsResponse> GetAsync(
        [FromServices] IMediator mediator,
        [FromQuery] GetDoctorsRequest? request,
        CancellationToken cancellationToken)
        => await mediator.Send(
            request == null
                ? new GetDoctorsQuery()
                : new GetDoctorsQuery
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
    [ProducesResponseType(type: typeof(GetDoctorByIdResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(type: typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<GetDoctorByIdResponse> GetByIdAsync(
        [FromServices] IMediator mediator,
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
        => await mediator.Send(new GetDoctorByIdQuery(id), cancellationToken);

    /// <summary>
    /// Обновить доктора
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
        [FromBody] PutDoctorRequest request,
        CancellationToken cancellationToken)
        => await mediator
            .Send(
                new PutDoctorCommand(id)
                {
                    Surname = request.Surname,
                    Name = request.Name,
                    Patronymic = request.Patronymic,
                    OfficeId = request.OfficeId,
                    SpecializationId = request.SpecializationId,
                    PlotId = request.PlotId
                },
            cancellationToken);

    /// <summary>
    /// Удалить доктора
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
        => await mediator.Send(new DeleteDoctorCommand(id), cancellationToken);
}