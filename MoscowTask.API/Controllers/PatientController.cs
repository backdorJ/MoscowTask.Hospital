using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoscowTask.Contracts.PatientRequests.GetPatients;
using MoscowTask.Contracts.Requests;
using MoscowTask.Contracts.Requests.PatientRequests.GetPatientById;
using MoscowTask.Contracts.Requests.PatientRequests.PostPatient;
using MoscowTask.Contracts.Requests.PatientRequests.PutPatient;
using MoscowTask.Core.Requests.PatientRequests.DeletePatient;
using MoscowTask.Core.Requests.PatientRequests.GetPatientById;
using MoscowTask.Core.Requests.PatientRequests.GetPatients;
using MoscowTask.Core.Requests.PatientRequests.PostPatient;
using MoscowTask.Core.Requests.PatientRequests.PutPatient;

namespace MoscowTask.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : BaseCrudController<
    PostPatientRequest,
    GetPatientsRequest,
    PutPatientRequest,
    GetPatientsResponse,
    GetPatientByIdResponse,
    PostPatientResponse>
{
}