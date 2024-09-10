using MediatR;

namespace MoscowTask.Core.Requests.PatientRequests.DeletePatient;

/// <summary>
/// Команда на удаление пациента
/// </summary>
public class DeletePatientCommand : CommandBase<Unit>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор</param>
    public DeletePatientCommand(Guid id)
        : base(id)
    {
    }
}