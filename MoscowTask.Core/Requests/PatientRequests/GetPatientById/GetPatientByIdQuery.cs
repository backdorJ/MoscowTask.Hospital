using MediatR;
using MoscowTask.Contracts.Requests.PatientRequests.GetPatientById;

namespace MoscowTask.Core.Requests.PatientRequests.GetPatientById;

/// <summary>
/// Запрос на получение пациента по идентификатору
/// </summary>
public class GetPatientByIdQuery : Query<GetPatientByIdResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор</param>
    public GetPatientByIdQuery(Guid id)
        : base(id)
    {
    }
}