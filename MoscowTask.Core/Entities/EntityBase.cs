namespace MoscowTask.Core.Entities;

/// <summary>
/// Базовая сущность
/// </summary>
public class EntityBase
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; private set; }
}