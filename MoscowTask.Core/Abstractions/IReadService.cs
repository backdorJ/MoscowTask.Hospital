using MoscowTask.Core.Entities;

namespace MoscowTask.Core.Abstractions;

public interface IReadService<TEntity>
    where TEntity : EntityBase
{
    /// <summary>
    /// Получить сущности
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Сущности</returns>
    protected Task<TEntity> GetEntitiesAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получить сущность по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Сущность</returns>
    protected Task<TEntity> GetEntityByIdAsync(Guid id, CancellationToken cancellationToken);
}