using MediatR;
using Microsoft.EntityFrameworkCore;
using MoscowTask.Contracts.Enums;
using MoscowTask.Contracts.PatientRequests.GetPatients;
using MoscowTask.Core.Abstractions;
using MoscowTask.Core.QueryableExtensions;

namespace MoscowTask.Core.Requests.PatientRequests.GetPatients;

/// <summary>
/// Обработчик для <see cref="GetPatientsQuery"/>
/// </summary>
public class GetPatientsQueryHandler : IRequestHandler<GetPatientsQuery, GetPatientsResponse>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public GetPatientsQueryHandler(IDbContext dbContext)
        => _dbContext = dbContext;

    /// <inheritdoc />
    public async Task<GetPatientsResponse> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var query = _dbContext.Patients;

        var totalCount = await query.CountAsync(cancellationToken);

        var result = await query
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