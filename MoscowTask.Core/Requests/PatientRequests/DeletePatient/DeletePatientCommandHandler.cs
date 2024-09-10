using MediatR;
using Microsoft.EntityFrameworkCore;
using MoscowTask.Core.Abstractions;
using MoscowTask.Core.Entities;
using MoscowTask.Core.Exceptions;

namespace MoscowTask.Core.Requests.PatientRequests.DeletePatient;

/// <summary>
/// Обработчик для <see cref="DeletePatientCommand"/>
/// </summary>
public class DeletePatientCommandHandler : CommandHandlerBase<DeletePatientCommand, Unit>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public DeletePatientCommandHandler(IDbContext dbContext)
        => _dbContext = dbContext;
    
    /// <inheritdoc />
    protected override async Task<Unit> GetResponse(DeletePatientCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command.Id);
        
        var patient = await _dbContext.Patients
            .FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken)
            ?? throw new EntityNotFoundException<Patient>(command.Id.Value);

        _dbContext.Patients.Remove(patient);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return default!;
    }
}