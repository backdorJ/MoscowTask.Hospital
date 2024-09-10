namespace MoscowTask.Contracts.Requests.PatientRequests.PostPatient;

/// <summary>
/// Ответ на <see cref="PostPatientRequest"/>
/// </summary>
public class PostPatientResponse : BasePostResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор</param>
    public PostPatientResponse(Guid id) : base(id)
    {
    }
}