namespace MoscowTask.Contracts.DoctorsRequests;

/// <summary>
/// Базовый запрос на создание/обновление сущности
/// </summary>
public class BaseUpsertRequest
{
    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname { get; set; } = default!;

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Отчество
    /// </summary>
    public string? Patronymic { get; set; }
    
    /// <summary>
    /// Идентификатор кабинета
    /// </summary>
    public Guid OfficeId { get; set; }

    /// <summary>
    /// Идентификатор специализации
    /// </summary>
    public Guid SpecializationId { get; set; }

    /// <summary>
    /// Идентификатор участка
    /// </summary>
    public Guid PlotId { get; set; }
}