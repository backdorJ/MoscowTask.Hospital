using MediatR;
using MoscowTask.Contracts.PatientRequests.GetPatients;
using MoscowTask.Core.Abstractions;

namespace MoscowTask.Core.Requests.PatientRequests.GetPatients;

/// <summary>
/// Запрос на получение пациентов
/// </summary>
public class GetPatientsQuery : Query<GetPatientsResponse, GetPatientsRequest>
{
    /// <summary>
    /// Конструктоо
    /// </summary>
    /// <param name="request"></param>
    /// <param name="id"></param>
    public GetPatientsQuery(GetPatientsRequest? request, Guid? id)
        : base(request, id)
    {
    }
}