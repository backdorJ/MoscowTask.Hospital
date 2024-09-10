using MoscowTask.Contracts.Enums;

namespace MoscowTask.Contracts.Requests.PatientRequests;

/// <summary>
/// Базовый ответ для пациента
/// </summary>
public class BasePatientResponse
{
    /// <summary>
    /// Идентификатор
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
    /// Адрес
    /// </summary>
    public string Address { get; set; } = default!;

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateOnly Birthday { get; set; }

    /// <summary>
    /// Пол
    /// </summary>
    public Gender Gender { get; set; } = default!;

    /// <summary>
    /// Номер участка
    /// </summary>
    public string NumberPlot { get; set; } = default!;
}