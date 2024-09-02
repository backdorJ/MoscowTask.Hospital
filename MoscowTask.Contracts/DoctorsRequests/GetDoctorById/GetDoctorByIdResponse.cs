namespace MoscowTask.Contracts.DoctorsRequests.GetDoctorById;

/// <summary>
/// Ответ на запрос о получение доктора
/// </summary>
public class GetDoctorByIdResponse
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
    /// Идентификатор кабинета
    /// </summary>
    public Guid OfficeId { get; set; }

    /// <summary>
    /// Номер кабинета
    /// </summary>
    public string OfficeNumber { get; set; } = default!;

    /// <summary>
    /// Идентификатор специализации
    /// </summary>
    public Guid SpecializationId { get; set; }

    /// <summary>
    /// Название специализации
    /// </summary>
    public string SpecializationName { get; set; } = default!;

    /// <summary>
    /// Идентификатор участка
    /// </summary>
    public Guid PlotId { get; set; }

    /// <summary>
    /// Название участка
    /// </summary>
    public string PlotNumber { get; set; } = default!;
}