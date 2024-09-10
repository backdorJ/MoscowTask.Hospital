using Microsoft.EntityFrameworkCore;
using MoscowTask.Contracts.Requests.DoctorsRequests.GetDoctorById;
using MoscowTask.Core.Abstractions;
using MoscowTask.Core.Entities;
using MoscowTask.Core.Exceptions;

namespace MoscowTask.Core.Requests.DoctorRequests.GetDoctorById;

/// <summary>
/// Обработчик для <see cref="GetDoctorByIdQuery"/>
/// </summary>
public class GetDoctorByIdQueryHandler : QueryHandlerBase<GetDoctorByIdQuery, GetDoctorByIdResponse>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public GetDoctorByIdQueryHandler(IDbContext dbContext)
        => _dbContext = dbContext;

    /// <inheritdoc />
    protected override async Task<GetDoctorByIdResponse> GetResponse(GetDoctorByIdQuery query, CancellationToken cancellationToken)
        => await _dbContext.Doctors
               .Select(x => new GetDoctorByIdResponse
               {
                   Id = x.Id,
                   Surname = x.Surname,
                   Name = x.Name,
                   Patronymic = x.Patronymic,
                   OfficeId = x.OfficeId,
                   OfficeNumber = x.Office!.Number,
                   SpecializationId = x.SpecializationId,
                   SpecializationName = x.Specialization!.Name,
                   PlotId = x.PlotId,
                   IsHavePlot = x.Plot != null,
                   PlotNumber = x.Plot!.Number,
               })
               .FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken)
                ?? throw new EntityNotFoundException<Doctor>(query.Id ?? throw new ArgumentNullException(nameof(query)));
}