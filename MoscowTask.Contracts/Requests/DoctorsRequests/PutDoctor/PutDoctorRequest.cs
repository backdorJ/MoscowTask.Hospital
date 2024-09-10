using MoscowTask.Contracts.Abstractions;

namespace MoscowTask.Contracts.DoctorsRequests.PutDoctor;

/// <summary>
/// Запрос на изменение доктора
/// </summary>
public class PutDoctorRequest : BaseUpsertRequest, IEntityId
{
    /// <summary>
    /// Идентфикатор
    /// </summary>
    public Guid? Id { get; set; }
}