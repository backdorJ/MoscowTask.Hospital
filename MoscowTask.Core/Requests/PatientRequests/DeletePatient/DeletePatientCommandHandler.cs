using MediatR;
using Microsoft.EntityFrameworkCore;
using MoscowTask.Core.Abstractions;

namespace MoscowTask.Core.Requests.PatientRequests.DeletePatient;

/// <summary>
/// Обработчик для <see cref="DeletePatientCommand"/>
/// </summary>
public class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public DeletePatientCommandHandler(IDbContext dbContext)
        => _dbContext = dbContext;

    /// <inheritdoc />
    public async Task Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var patient = await _dbContext.Patients
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new ArgumentNullException(nameof(request.Id));

        _dbContext.Patients.Remove(patient);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}