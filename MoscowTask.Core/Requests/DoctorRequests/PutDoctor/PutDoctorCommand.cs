using MediatR;
using MoscowTask.Contracts.DoctorsRequests.PutDoctor;
using MoscowTask.Contracts.Requests;

namespace MoscowTask.Core.Requests.DoctorRequests.PutDoctor;

/// <summary>
/// Запрос на обновление доктора
/// </summary>
public class PutDoctorCommand : CommandBase<Unit, PutDoctorRequest>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="request">Запрос</param>
    public PutDoctorCommand(Guid id, PutDoctorRequest request)
        : base(request, id)
    {
    }
}