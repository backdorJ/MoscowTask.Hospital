using MediatR;
using Microsoft.EntityFrameworkCore;
using MoscowTask.Contracts.Requests.PatientRequests.GetPatientById;
using MoscowTask.Core.Abstractions;
using MoscowTask.Core.Entities;
using MoscowTask.Core.Exceptions;

namespace MoscowTask.Core.Requests.PatientRequests.GetPatientById;

/// <summary>
/// Обработчик для <see cref="GetPatientByIdQuery"/>
/// </summary>
public class GetPatientByIdQueryHandler : QueryHandlerBase<GetPatientByIdQuery, GetPatientByIdResponse>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public GetPatientByIdQueryHandler(IDbContext dbContext)
        => _dbContext = dbContext;
    
    /// <inheritdoc />
    protected override async Task<GetPatientByIdResponse> GetResponse(GetPatientByIdQuery query, CancellationToken cancellationToken)
        => await _dbContext.Patients
               .Select(x => new GetPatientByIdResponse
               {
                   Id = x.Id,
                   Surname = x.Surname,
                   Name = x.Name,
                   Patronymic = x.Patronymic,
                   Address = x.Address,
                   Birthday = x.Birthday,
                   Gender = x.Gender,
                   NumberPlot = x.Plot!.Number,
                   PlotId = x.PlotId
               })
               .FirstOrDefaultAsync(x => x.Id == query.Id, cancellationToken)
           ?? throw new EntityNotFoundException<Patient>(query.Id ?? throw new ArgumentNullException(nameof(query)));
}