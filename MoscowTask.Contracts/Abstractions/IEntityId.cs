namespace MoscowTask.Contracts.Abstractions;

public interface IEntityId
{
    /// <summary>
    /// Идентификатор сущности
    /// </summary>
    public Guid? Id { get; set; }
}