using Microsoft.EntityFrameworkCore;
using MoscowTask.Contracts.DoctorsRequests.GetDoctors;
using MoscowTask.Contracts.Requests.DoctorsRequests.GetDoctors;
using MoscowTask.Core.Abstractions;
using MoscowTask.Core.QueryableExtensions;

namespace MoscowTask.Core.Requests.DoctorRequests.GetDoctors;

/// <summary>
/// Обработчик для <see cref="GetDoctorsQuery"/>
/// </summary>
public class GetDoctorsQueryHandler : QueryHandlerBase<GetDoctorsQuery, GetDoctorsResponse>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public GetDoctorsQueryHandler(IDbContext dbContext)
        => _dbContext = dbContext;

    /// <inheritdoc />
    protected override async Task<GetDoctorsResponse> GetResponse(GetDoctorsQuery query, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(query.Request);
        var request = query.Request;
        var doctors = _dbContext.Doctors;

        var totalCount = await doctors.CountAsync(cancellationToken);

        var result = await doctors
            .Select(x => new GetDoctorsResponseItem
            {
                Id = x.Id,
                Surname = x.Surname,
                Name = x.Name,
                Patronymic = x.Patronymic,
                OfficeNumber = x.Office!.Number,
                SpecializationName = x.Specialization!.Name,
                PlotNumber = x.Plot!.Number,
            })
            .OrderBy(request)
            .SkipTake(request)
            .ToListAsync(cancellationToken);

        return new GetDoctorsResponse(result, totalCount);
    }
}