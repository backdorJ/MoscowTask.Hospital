using MoscowTask.Contracts.Enums;

namespace MoscowTask.Contracts.PatientRequests;

/// <summary>
/// Базовый запрос на создание/изменение
/// </summary>
public class UpsertPatientRequest
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
    public Gender Gender { get; set; }

    /// <summary>
    /// Идентификатор участка
    /// </summary>
    public Guid PlotId { get; set; }
}