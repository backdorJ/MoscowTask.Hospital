using MoscowTask.Contracts.Requests.DoctorsRequests.GetDoctors;

namespace MoscowTask.Contracts.DoctorsRequests.GetDoctors;

/// <summary>
/// Ответ на <see cref="GetDoctorsRequest"/>
/// </summary>
public class GetDoctorsResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="entities">Доктора</param>
    /// <param name="totalCount">Общее кол-во</param>
    public GetDoctorsResponse(List<GetDoctorsResponseItem>? entities, int totalCount)
    {
        Entities = entities;
        TotalCount = totalCount;
    }

    /// <summary>
    /// Доктора
    /// </summary>
    public List<GetDoctorsResponseItem>? Entities { get; set; }

    /// <summary>
    /// Общее кол-во
    /// </summary>
    public int TotalCount { get; set; }
}