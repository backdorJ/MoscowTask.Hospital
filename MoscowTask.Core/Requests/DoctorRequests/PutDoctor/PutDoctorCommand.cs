using MediatR;
using MoscowTask.Contracts.DoctorsRequests.PutDoctor;

namespace MoscowTask.Core.Requests.DoctorRequests.PutDoctor;

/// <summary>
/// Запрос на обновление доктора
/// </summary>
public class PutDoctorCommand : PutDoctorRequest, IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор</param>
    public PutDoctorCommand(Guid id)
        => Id = id;

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; }
}