namespace MoscowTask.Contracts.Requests.PatientRequests.GetPatientById;

/// <summary>
/// Ответ на запрос о получении пациента по идентификатору
/// </summary>
public class GetPatientByIdResponse : BasePatientResponse
{
    /// <summary>
    /// Идентификатор участка
    /// </summary>
    public Guid PlotId { get; set; }
}