using MediatR;
using Microsoft.EntityFrameworkCore;
using MoscowTask.Contracts.DoctorsRequests.GetDoctors;
using MoscowTask.Core.Abstractions;
using MoscowTask.Core.QueryableExtensions;

namespace MoscowTask.Core.Requests.DoctorRequests.GetDoctors;

/// <summary>
/// Обработчик для <see cref="GetDoctorsQuery"/>
/// </summary>
public class GetDoctorsQueryHandler : IRequestHandler<GetDoctorsQuery, GetDoctorsResponse>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public GetDoctorsQueryHandler(IDbContext dbContext)
        => _dbContext = dbContext;

    /// <inheritdoc />
    public async Task<GetDoctorsResponse> Handle(GetDoctorsQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var query = _dbContext.Doctors;

        var totalCount = await query.CountAsync(cancellationToken);

        var result = await query
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