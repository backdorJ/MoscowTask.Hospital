using MoscowTask.Contracts.Requests.DoctorsRequests.GetDoctorById;

namespace MoscowTask.Core.Requests.DoctorRequests.GetDoctorById;

/// <summary>
/// Запрос на получение доктора
/// </summary>
public class GetDoctorByIdQuery : Query<GetDoctorByIdResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор</param>
    public GetDoctorByIdQuery(Guid id)
        : base(id)
    {
    }
}