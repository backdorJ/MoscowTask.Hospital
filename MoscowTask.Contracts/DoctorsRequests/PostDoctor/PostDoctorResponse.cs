namespace MoscowTask.Contracts.DoctorsRequests.PostDoctor;

/// <summary>
/// Ответ для <see cref="PostDoctorRequest"/>
/// </summary>
public class PostDoctorResponse
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор</param>
    public PostDoctorResponse(Guid id)
        => Id = id;

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
}