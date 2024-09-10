using MediatR;
using MoscowTask.Contracts.DoctorsRequests.PostDoctor;
using MoscowTask.Contracts.Requests;

namespace MoscowTask.Core.Requests.DoctorRequests.PostDoctor;

/// <summary>
/// Команда на создание доктора
/// </summary>
public class PostDoctorCommand : CommandBase<BasePostResponse, PostDoctorRequest>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="commandRequest">Запрос</param>
    public PostDoctorCommand(PostDoctorRequest? commandRequest)
        : base(commandRequest, default)
    {
    }
}