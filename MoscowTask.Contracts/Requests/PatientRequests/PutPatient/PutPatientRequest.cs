using MoscowTask.Contracts.Abstractions;
using MoscowTask.Contracts.PatientRequests;

namespace MoscowTask.Contracts.Requests.PatientRequests.PutPatient;

/// <summary>
/// Запрос на изменение пациента
/// </summary>
public class PutPatientRequest : UpsertPatientRequest, IEntityId
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid? Id { get; set; }
}