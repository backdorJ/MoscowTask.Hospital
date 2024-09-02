using MediatR;
using MoscowTask.Contracts.DoctorsRequests.GetDoctorById;

namespace MoscowTask.Core.Requests.DoctorRequests.GetDoctorById;

/// <summary>
/// Запрос на получение доктора
/// </summary>
public class GetDoctorByIdQuery : IRequest<GetDoctorByIdResponse>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор</param>
    public GetDoctorByIdQuery(Guid id)
        => Id = id;

    /// <summary>
    /// Идентификатор доктора
    /// </summary>
    public Guid Id { get; set; }
}