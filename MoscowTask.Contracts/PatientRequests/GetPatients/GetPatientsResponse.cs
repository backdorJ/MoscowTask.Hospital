namespace MoscowTask.Contracts.PatientRequests.GetPatients;

/// <summary>
/// Ответ на <see cref="GetPatientsRequest"/>
/// </summary>
public class GetPatientsResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="entities">Паценты</param>
    /// <param name="totalCount">Общее кол-во</param>
    public GetPatientsResponse(List<GetPatientsResponseItem>? entities, int totalCount)
    {
        Entities = entities;
        TotalCount = totalCount;
    }

    /// <summary>
    /// Пациенты
    /// </summary>
    public List<GetPatientsResponseItem>? Entities { get; set; }

    /// <summary>
    /// Общее кол-во
    /// </summary>
    public int TotalCount { get; set; }
}