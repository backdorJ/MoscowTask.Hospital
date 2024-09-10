using MoscowTask.Contracts.DoctorsRequests.GetDoctors;

namespace MoscowTask.Core.Requests.DoctorRequests.GetDoctors;

/// <summary>
/// Запрос на получение докторов
/// </summary>
public class GetDoctorsQuery : Query<GetDoctorsResponse, GetDoctorsRequest>
{
    protected GetDoctorsQuery(GetDoctorsRequest? request, Guid? id)
        : base(request, id)
    {
    }
}