namespace MoscowTask.Contracts.Requests.DoctorsRequests;

/// <summary>
/// Базовый ответ для доктора
/// </summary>
public class BaseDoctorGetResponse
{
    /// <summary>
    /// Идентификатор доктора
    /// </summary>
    public Guid Id { get; set; }
    
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
    /// Номер кабинета
    /// </summary>
    public string OfficeNumber { get; set; } = default!;

    /// <summary>
    /// Название специализации
    /// </summary>
    public string SpecializationName { get; set; } = default!;

    /// <summary>
    /// Название участка
    /// </summary>
    public string PlotNumber { get; set; } = default!;
}