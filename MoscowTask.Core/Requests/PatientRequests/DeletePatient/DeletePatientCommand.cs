using MediatR;

namespace MoscowTask.Core.Requests.PatientRequests.DeletePatient;

/// <summary>
/// Команда на удаление пациента
/// </summary>
public class DeletePatientCommand : IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор</param>
    public DeletePatientCommand(Guid id)
        => Id = id;

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; }
}