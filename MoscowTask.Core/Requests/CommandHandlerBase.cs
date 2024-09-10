using MediatR;

namespace MoscowTask.Core.Requests;

/// <summary>
/// Базовая команда
/// </summary>
/// <typeparam name="TResponse">Ответ</typeparam>
/// <typeparam name="TCommandRequest"></typeparam>
public class CommandBase<TResponse, TCommandRequest> : CommandBase<TResponse>
    where TCommandRequest : class
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="commandRequest">Запрос команды</param>
    /// <param name="id">Идентификатор</param>
    public CommandBase(TCommandRequest? commandRequest, Guid? id)
        : base(id)
        => CommandRequest = commandRequest;

    /// <summary>
    /// Запрос команды
    /// </summary>
    public TCommandRequest? CommandRequest { get; }
}

/// <summary>
/// Базовая команда без запроса
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public class CommandBase<TResponse> : IRequest<TResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор</param>
    public CommandBase(Guid? id)
        => Id = id;

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid? Id { get; }
}

/// <summary>
/// Базовый обработчик 
/// </summary>
/// <typeparam name="TCommandBase">Базовая команда</typeparam>
/// <typeparam name="TResponse">Результат</typeparam>
public abstract class CommandHandlerBase<TCommandBase, TResponse> : IRequestHandler<TCommandBase, TResponse>
    where TCommandBase : CommandBase<TResponse>
{
    /// <inheritdoc/>
    public async Task<TResponse> Handle(TCommandBase request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        return await GetResponse(request, cancellationToken);
    }

    /// <summary>
    /// Логика обработчика
    /// </summary>
    /// <param name="command">Запрос</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Результат</returns>
    protected abstract Task<TResponse> GetResponse(TCommandBase command, CancellationToken cancellationToken);
}