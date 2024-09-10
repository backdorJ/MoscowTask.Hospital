using MediatR;
using Microsoft.EntityFrameworkCore;
using MoscowTask.Core.Abstractions;
using MoscowTask.Core.Entities;
using MoscowTask.Core.Exceptions;

namespace MoscowTask.Core.Requests.PatientRequests.PutPatient;

/// <summary>
/// Обработчик для <see cref="PutPatientCommand"/>
/// </summary>
public class PutPatientCommandHandler : CommandHandlerBase<PutPatientCommand, Unit>
{
    private readonly IDbContext _dbContext;
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public PutPatientCommandHandler(IDbContext dbContext)
        => _dbContext = dbContext;

    /// <inheritdoc />
    protected override async Task<Unit> GetResponse(PutPatientCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command.CommandRequest);
        var request = command.CommandRequest;
        
        var patient = await _dbContext.Patients
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new EntityNotFoundException<Patient>(request.Id ?? default);

        var plot = await _dbContext.Plots
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new EntityNotFoundException<Plot>(request.Id ?? default);
        
        patient.Gender = request.Gender;
        patient.Address = request.Address;
        patient.Birthday = request.Birthday;
        patient.Plot = plot;
        patient.Name = request.Name;
        patient.Surname = request.Surname;
        patient.Patronymic = request.Patronymic;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return default!;
    }
}