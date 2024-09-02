using MediatR;

namespace MoscowTask.Core.Requests.DoctorRequests.DeleteDoctor;

/// <summary>
/// Запрос на удаление доктора
/// </summary>
public class DeleteDoctorCommand : IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор</param>
    public DeleteDoctorCommand(Guid id)
        => Id = id;

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; }
}