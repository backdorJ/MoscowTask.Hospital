using MediatR;
using MoscowTask.Contracts.Requests.PatientRequests.PutPatient;

namespace MoscowTask.Core.Requests.PatientRequests.PutPatient;

/// <summary>
/// Запрос на изменение пациента
/// </summary>
public class PutPatientCommand : CommandBase<Unit, PutPatientRequest>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="request">Запрос</param>
    public PutPatientCommand(Guid id, PutPatientRequest request)
        : base(request, id)
    {
    }
}