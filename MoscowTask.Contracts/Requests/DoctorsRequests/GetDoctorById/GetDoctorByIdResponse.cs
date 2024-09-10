namespace MoscowTask.Contracts.Requests.DoctorsRequests.GetDoctorById;

/// <summary>
/// Ответ на запрос о получение доктора
/// </summary>
public class GetDoctorByIdResponse : BaseDoctorGetResponse
{
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

    /// <summary>
    /// Участковый ли
    /// </summary>
    public bool IsHavePlot { get; set; }
}