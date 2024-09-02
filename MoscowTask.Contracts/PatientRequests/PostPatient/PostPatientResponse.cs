namespace MoscowTask.Contracts.PatientRequests.PostPatient;

/// <summary>
/// Ответ на <see cref="PostPatientRequest"/>
/// </summary>
public class PostPatientResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор</param>
    public PostPatientResponse(Guid id)
        => Id = id;

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
}