using MediatR;
using MoscowTask.Contracts.PatientRequests.GetPatients;
using MoscowTask.Core.Abstractions;

namespace MoscowTask.Core.Requests.PatientRequests.GetPatients;

/// <summary>
/// Запрос на получение пациентов
/// </summary>
public class GetPatientsQuery
    : GetPatientsRequest, IRequest<GetPatientsResponse>, IPaginationQuery, IOrderByQuery 
{
    
}