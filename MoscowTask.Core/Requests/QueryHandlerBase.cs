using MediatR;

namespace MoscowTask.Core.Requests;

public class Query<TResponse> : IRequest<TResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id"></param>
    public Query(Guid? id)
        => Id = id;

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid? Id { get; set; }
}

public class Query<TResponse, TRequest> : Query<TResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    /// <param name="id">Идентификатор</param>
    public Query(TRequest? request, Guid? id)
        : base(id)
        => Request = request;

    /// <summary>
    /// Запрос
    /// </summary>
    public TRequest? Request { get; set; }
}

public abstract class QueryHandlerBase<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : Query<TResponse>
{
    /// <inheritdoc/>
    public async Task<TResponse> Handle(TQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        return await GetResponse(request, cancellationToken);
    }

    /// <summary>
    /// Получить результат
    /// </summary>
    /// <param name="query">Запрос</param>
    /// <param name="cancellationToken">Токен</param>
    /// <returns>Результат</returns>
    protected abstract Task<TResponse> GetResponse(TQuery query, CancellationToken cancellationToken);
}