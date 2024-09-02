using MediatR;
using Microsoft.EntityFrameworkCore;
using MoscowTask.Contracts.DoctorsRequests.GetDoctorById;
using MoscowTask.Core.Abstractions;

namespace MoscowTask.Core.Requests.DoctorRequests.GetDoctorById;

/// <summary>
/// Обработчик для <see cref="GetDoctorByIdQuery"/>
/// </summary>
public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, GetDoctorByIdResponse>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public GetDoctorByIdQueryHandler(IDbContext dbContext)
        => _dbContext = dbContext;

    /// <inheritdoc />
    public async Task<GetDoctorByIdResponse> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        return await _dbContext.Doctors
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
                PlotNumber = x.Plot!.Number
            })
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new ArgumentNullException(nameof(request.Id));
    }
}