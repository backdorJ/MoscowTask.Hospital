namespace MoscowTask.Core.Abstractions;

public interface ICrudService<
    TGetsResponse,
    TGetByIdResponse,
    TPostResponse,
    in TPostRequest>
{
    /// <summary>
    /// Получить сущности
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Сущности</returns>
    public Task<TGetsResponse> GetEntitiesAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получить сущность по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Сущность</returns>
    public Task<TGetByIdResponse> GetEntityByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Создать сущность
    /// </summary>
    /// <param name="request">Запрос</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Идентификатор сущности</returns>
    public Task<TPostResponse> PostEntityAsync(TPostRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Изменить сущность
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>-</returns>
    public Task PutEntityAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Удалить сущность
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>-</returns>
    public Task DeleteEntityAsync(Guid id, CancellationToken cancellationToken);
}