using MediatR;
using Microsoft.EntityFrameworkCore;
using MoscowTask.Core.Abstractions;

namespace MoscowTask.Core.Requests.DoctorRequests.PutDoctor;

/// <summary>
/// Обработчик для <see cref="PutDoctorCommand"/>
/// </summary>
public class PutDoctorCommandHandler : IRequestHandler<PutDoctorCommand>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public PutDoctorCommandHandler(IDbContext dbContext)
        => _dbContext = dbContext;

    /// <inheritdoc />
    public async Task Handle(PutDoctorCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var office = await _dbContext.Offices
            .FirstOrDefaultAsync(x => x.Id == request.OfficeId, cancellationToken)
            ?? throw new ArgumentNullException(nameof(request.OfficeId));
        
        var specialization = await _dbContext.Specializations
            .FirstOrDefaultAsync(x => x.Id == request.SpecializationId, cancellationToken)
            ?? throw new ArgumentNullException(nameof(request.SpecializationId));
        
        var plot = await _dbContext.Plots
            .FirstOrDefaultAsync(x => x.Id == request.PlotId, cancellationToken)
            ?? throw new ArgumentNullException(nameof(request.PlotId));
        
        var doctor = await _dbContext.Doctors
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new ArgumentNullException(nameof(request.Id));

        doctor.Surname = request.Surname;
        doctor.Name = request.Name;
        doctor.Patronymic = request.Patronymic;
        doctor.Office = office;
        doctor.Specialization = specialization;
        doctor.Plot = plot;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}