using MoscowTask.Contracts.Requests;
using MoscowTask.Contracts.Requests.PatientRequests.PostPatient;

namespace MoscowTask.Core.Requests.PatientRequests.PostPatient;

/// <summary>
/// Команда на создание пациента
/// </summary>
public class PostPatientCommand : CommandBase<BasePostResponse, PostPatientRequest>
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="commandRequest">Запрос</param>
    public PostPatientCommand(PostPatientRequest? commandRequest)
        : base(commandRequest, default)
    {
    }
}