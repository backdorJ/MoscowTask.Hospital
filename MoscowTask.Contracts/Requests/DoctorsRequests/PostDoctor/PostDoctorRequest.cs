using MoscowTask.Contracts.Abstractions;

namespace MoscowTask.Contracts.DoctorsRequests.PostDoctor;

/// <summary>
/// Запрос на создание врача
/// </summary>
public class PostDoctorRequest : BaseUpsertRequest, IEntityId
{
    public Guid? Id { get; set; }
}