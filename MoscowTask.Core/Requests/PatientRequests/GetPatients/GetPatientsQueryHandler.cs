using Microsoft.EntityFrameworkCore;
using MoscowTask.Contracts.PatientRequests.GetPatients;
using MoscowTask.Contracts.Requests.PatientRequests.GetPatients;
using MoscowTask.Core.Abstractions;
using MoscowTask.Core.QueryableExtensions;

namespace MoscowTask.Core.Requests.PatientRequests.GetPatients;

/// <summary>
/// Обработчик для <see cref="GetPatientsQuery"/>
/// </summary>
public class GetPatientsQueryHandler : QueryHandlerBase<GetPatientsQuery, GetPatientsResponse>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public GetPatientsQueryHandler(IDbContext dbContext)
        => _dbContext = dbContext;

    /// <inheritdoc />
    protected override async Task<GetPatientsResponse> GetResponse(GetPatientsQuery query, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(query.Request);
        var request = query.Request;
        var patients = _dbContext.Patients;

        var totalCount = await patients.CountAsync(cancellationToken);

        var result = await patients
            .Select(x => new GetPatientsResponseItem
            {
                Id = x.Id,
                Surname = x.Surname,
                Name = x.Name,
                Patronymic = x.Patronymic,
                Address = x.Address,
                Birthday = x.Birthday,
                Gender = x.Gender,
                NumberPlot = x.Plot!.Number,
            })
            .OrderBy(request)
            .SkipTake(request)
            .ToListAsync(cancellationToken);

        return new GetPatientsResponse(result, totalCount);
    }
}