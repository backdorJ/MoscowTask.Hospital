using MoscowTask.Contracts.DoctorsRequests.PostDoctor;

namespace MoscowTask.Contracts.Requests.DoctorsRequests.PostDoctor;

/// <summary>
/// Ответ для <see cref="PostDoctorRequest"/>
/// </summary>
public class PostDoctorResponse : BasePostResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор</param>
    public PostDoctorResponse(Guid id)
        : base(id)
    {
    }
}