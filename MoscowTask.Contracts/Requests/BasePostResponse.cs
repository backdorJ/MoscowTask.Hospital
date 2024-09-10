namespace MoscowTask.Contracts.Requests;

/// <summary>
/// Базовый ответ на создание сущности
/// </summary>
public class BasePostResponse 
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор созданной сущности</param>
    public BasePostResponse(Guid id)
        => Id = id;

    /// <summary>
    /// Идентификатор созданной сущности
    /// </summary>
    public Guid Id { get; set; }
}