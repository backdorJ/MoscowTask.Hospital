using MediatR;
using MoscowTask.Contracts.DoctorsRequests.PostDoctor;

namespace MoscowTask.Core.Requests.DoctorRequests.PostDoctor;

/// <summary>
/// Команда на создание доктора
/// </summary>
public class PostDoctorCommand : PostDoctorRequest, IRequest<PostDoctorResponse>
{
}