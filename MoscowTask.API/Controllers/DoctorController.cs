using Microsoft.AspNetCore.Mvc;
using MoscowTask.Contracts.DoctorsRequests.GetDoctors;
using MoscowTask.Contracts.DoctorsRequests.PostDoctor;
using MoscowTask.Contracts.DoctorsRequests.PutDoctor;
using MoscowTask.Contracts.Requests.DoctorsRequests.GetDoctorById;
using MoscowTask.Contracts.Requests.DoctorsRequests.PostDoctor;

namespace MoscowTask.API.Controllers;

/// <summary>
/// Контроллер по работе с врачами
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class DoctorController : BaseCrudController<
    PostDoctorRequest,
    GetDoctorsResponse,
    PutDoctorRequest,
    GetDoctorsResponse,
    GetDoctorByIdResponse,
    PostDoctorResponse>
{
}