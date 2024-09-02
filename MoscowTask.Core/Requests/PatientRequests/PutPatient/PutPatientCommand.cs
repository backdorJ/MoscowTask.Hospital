using MediatR;
using MoscowTask.Contracts.PatientRequests.PutPatient;

namespace MoscowTask.Core.Requests.PatientRequests.PutPatient;

/// <summary>
/// Запрос на изменение пациента
/// </summary>
public class PutPatientCommand : PutPatientRequest, IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор</param>
    public PutPatientCommand(Guid id)
        => Id = id;

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; }
}