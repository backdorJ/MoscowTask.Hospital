using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoscowTask.Contracts.Requests;
using MoscowTask.Core.Requests;

namespace MoscowTask.API.Controllers;

/// <summary>
/// Базовый CRUD контроллер
/// </summary>
/// <typeparam name="TEntity">Сущность</typeparam>
/// <typeparam name="TGetResponse"></typeparam>
/// <typeparam name="TGetByIdResponse"></typeparam>
/// <typeparam name="TCreateResponse"></typeparam>
/// <typeparam name="TPostRequest"></typeparam>
/// <typeparam name="TPutRequest"></typeparam>
/// <typeparam name="TGetRequest"></typeparam>
[ApiController]
[Route("api/[controller]")]
public class BaseCrudController<
    TPostRequest,
    TGetRequest,
    TPutRequest,
    TGetResponse,
    TGetByIdResponse,
    TCreateResponse> : ControllerBase 
    where TCreateResponse : BasePostResponse
    where TPutRequest : class
    where TPostRequest : class, new()
{
    /// <summary>
    /// Создать сущность
    /// </summary>
    /// <param name="request">Запрос</param>
    /// <param name="mediator">Медиатор CQRS</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Ответ</returns>
    [HttpPost]
    public async Task<TCreateResponse> CreateAsync(
        [FromBody] TPostRequest request,
        [FromServices] IMediator mediator,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        return await mediator.Send(
            new CommandBase<TCreateResponse, TPostRequest>(request, default),
            cancellationToken);
    }

    /// <summary>
    /// Получить список докторов
    /// </summary>
    /// <param name="mediator">Медиатор CQRS</param>
    /// <param name="request">Запрос</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список сущностей</returns>
    [HttpGet]
    public async Task<TGetResponse> GetAsync(
        [FromServices] IMediator mediator,
        [FromQuery] TGetRequest? request,
        CancellationToken cancellationToken)
        => await mediator.Send(
            new Query<TGetResponse, TGetRequest>(request, default),
            cancellationToken);
    
    /// <summary>
    /// Получить доктора по идентификатору
    /// </summary>
    /// <param name="mediator">Медиатор CQRS</param>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Доктор</returns>
    [HttpGet("{id}")]
    public async Task<TGetByIdResponse> GetByIdAsync(
        [FromServices] IMediator mediator,
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
        => await mediator.Send(new Query<TGetByIdResponse>(id), cancellationToken);

    /// <summary>
    /// Изменить сущность
    /// </summary>
    /// <param name="mediator">Медиатор CQRS</param>
    /// <param name="id">Идентификатор</param>
    /// <param name="request">Запрос</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPut("{id}")]
    public async Task PutAsync(
        [FromServices] IMediator mediator,
        [FromRoute] Guid id,
        [FromBody] TPutRequest request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        await mediator.Send(
            new CommandBase<Unit, TPutRequest>(request, id),
            cancellationToken);
    }

    /// <summary>
    /// Удалить сущность по идентификатору
    /// </summary>
    /// <param name="mediator">Медиатор CQRS</param>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpDelete("{id}")]
    public async Task DeleteAsync(
        [FromServices] IMediator mediator,
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
        => await mediator.Send(new CommandBase<Unit>(id), cancellationToken);
}