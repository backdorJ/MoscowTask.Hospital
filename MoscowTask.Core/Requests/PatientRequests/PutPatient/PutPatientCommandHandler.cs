using MediatR;
using Microsoft.EntityFrameworkCore;
using MoscowTask.Core.Abstractions;

namespace MoscowTask.Core.Requests.PatientRequests.PutPatient;

/// <summary>
/// Обработчик для <see cref="PutPatientCommand"/>
/// </summary>
public class PutPatientCommandHandler : IRequestHandler<PutPatientCommand>
{
    private readonly IDbContext _dbContext;
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public PutPatientCommandHandler(IDbContext dbContext)
        => _dbContext = dbContext;

    /// <inheritdoc />
    public async Task Handle(PutPatientCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        var patient = await _dbContext.Patients
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new ArgumentNullException(nameof(request.Id));

        var plot = await _dbContext.Plots
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new ArgumentNullException(nameof(request.Id));
        
        patient.Gender = request.Gender;
        patient.Address = request.Address;
        patient.Birthday = request.Birthday;
        patient.Plot = plot;
        patient.Name = request.Name;
        patient.Surname = request.Surname;
        patient.Patronymic = request.Patronymic;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}