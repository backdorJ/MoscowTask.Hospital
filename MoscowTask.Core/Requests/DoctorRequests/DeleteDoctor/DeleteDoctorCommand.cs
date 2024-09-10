using MediatR;

namespace MoscowTask.Core.Requests.DoctorRequests.DeleteDoctor;

/// <summary>
/// Запрос на удаление доктора
/// </summary>
public class DeleteDoctorCommand : CommandBase<Unit>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор</param>
    public DeleteDoctorCommand(Guid id)
        : base(id)
    {
    }
}