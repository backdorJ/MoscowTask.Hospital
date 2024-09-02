using MediatR;
using MoscowTask.Contracts.PatientRequests.PostPatient;

namespace MoscowTask.Core.Requests.PatientRequests.PostPatient;

/// <summary>
/// Команда на создание пациента
/// </summary>
public class PostPatientCommand : PostPatientRequest, IRequest<PostPatientResponse>
{
}