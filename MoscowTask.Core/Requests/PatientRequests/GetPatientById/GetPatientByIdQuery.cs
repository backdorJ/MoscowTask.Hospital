using MediatR;
using MoscowTask.Contracts.PatientRequests.GetPatientById;

namespace MoscowTask.Core.Requests.PatientRequests.GetPatientById;

/// <summary>
/// Запрос на получение пациента по идентификатору
/// </summary>
public class GetPatientByIdQuery : IRequest<GetPatientByIdResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор</param>
    public GetPatientByIdQuery(Guid id)
        => Id = id;

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; }
}