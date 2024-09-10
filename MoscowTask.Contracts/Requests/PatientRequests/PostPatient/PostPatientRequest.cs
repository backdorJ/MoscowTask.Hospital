using MoscowTask.Contracts.Abstractions;
using MoscowTask.Contracts.PatientRequests;

namespace MoscowTask.Contracts.Requests.PatientRequests.PostPatient;

/// <summary>
/// Запрос на создание пациента
/// </summary>
public class PostPatientRequest : UpsertPatientRequest, IEntityId
{
    /// <summary>
    /// Идентфикатор
    /// </summary>
    public Guid? Id { get; set; }
}