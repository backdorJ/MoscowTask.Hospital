using MediatR;
using Microsoft.EntityFrameworkCore;
using MoscowTask.Core.Abstractions;
using MoscowTask.Core.Entities;
using MoscowTask.Core.Exceptions;

namespace MoscowTask.Core.Requests.DoctorRequests.PutDoctor;

/// <summary>
/// Обработчик для <see cref="PutDoctorCommand"/>
/// </summary>
public class PutDoctorCommandHandler : CommandHandlerBase<PutDoctorCommand, Unit>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public PutDoctorCommandHandler(IDbContext dbContext)
        => _dbContext = dbContext;

    /// <inheritdoc />
    protected override async Task<Unit> GetResponse(PutDoctorCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command.Id);
        ArgumentNullException.ThrowIfNull(command.CommandRequest);
        var request = command.CommandRequest;
        
        var office = await _dbContext.Offices
            .FirstOrDefaultAsync(x => x.Id == request.OfficeId, cancellationToken)
            ?? throw new EntityNotFoundException<Office>(request.OfficeId);
        
        var specialization = await _dbContext.Specializations
            .FirstOrDefaultAsync(x => x.Id == request.SpecializationId, cancellationToken)
            ?? throw new EntityNotFoundException<Specialization>(request.SpecializationId);
        
        var plot = await _dbContext.Plots
            .FirstOrDefaultAsync(x => x.Id == request.PlotId, cancellationToken)
            ?? throw new EntityNotFoundException<Plot>(request.PlotId);
        
        var doctor = await _dbContext.Doctors
            .FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken)
            ?? throw new EntityNotFoundException<Doctor>(command.Id.Value);

        doctor.Surname = request.Surname;
        doctor.Name = request.Name;
        doctor.Patronymic = request.Patronymic;
        doctor.Office = office;
        doctor.Specialization = specialization;
        doctor.Plot = plot;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return default!;
    }
}