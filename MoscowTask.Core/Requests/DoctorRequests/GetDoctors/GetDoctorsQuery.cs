using MediatR;
using MoscowTask.Contracts.DoctorsRequests.GetDoctors;
using MoscowTask.Core.Abstractions;

namespace MoscowTask.Core.Requests.DoctorRequests.GetDoctors;

/// <summary>
/// Запрос на получение докторов
/// </summary>
public class GetDoctorsQuery : GetDoctorsRequest, IRequest<GetDoctorsResponse>, IPaginationQuery, IOrderByQuery
{
}