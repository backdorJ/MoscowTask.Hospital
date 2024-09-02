using MediatR;
using Microsoft.EntityFrameworkCore;
using MoscowTask.Contracts.PatientRequests.GetPatientById;
using MoscowTask.Core.Abstractions;

namespace MoscowTask.Core.Requests.PatientRequests.GetPatientById;

/// <summary>
/// Обработчик для <see cref="GetPatientByIdQuery"/>
/// </summary>
public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, GetPatientByIdResponse>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public GetPatientByIdQueryHandler(IDbContext dbContext)
        => _dbContext = dbContext;
    
    /// <inheritdoc />
    public async Task<GetPatientByIdResponse> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        return await _dbContext.Patients
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
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new ArgumentNullException(nameof(request.Id));
    }
}