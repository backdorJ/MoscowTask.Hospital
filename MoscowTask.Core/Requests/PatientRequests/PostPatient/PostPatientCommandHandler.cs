using MediatR;
using Microsoft.EntityFrameworkCore;
using MoscowTask.Contracts.PatientRequests.PostPatient;
using MoscowTask.Core.Abstractions;
using MoscowTask.Core.Entities;

namespace MoscowTask.Core.Requests.PatientRequests.PostPatient;

/// <summary>
/// Обработчик для <see cref="PostPatientCommand"/>
/// </summary>
public class PostPatientCommandHandler : IRequestHandler<PostPatientCommand, PostPatientResponse>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public PostPatientCommandHandler(IDbContext dbContext)
        => _dbContext = dbContext;

    /// <inheritdoc />
    public async Task<PostPatientResponse> Handle(PostPatientCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var plot = await _dbContext.Plots
            .FirstOrDefaultAsync(x => x.Id == request.PlotId, cancellationToken)
            ?? throw new ArgumentNullException(nameof(request.PlotId));

        var patient = new Patient(
            surname: request.Surname,
            name: request.Name,
            address: request.Address,
            birthday: request.Birthday,
            gender: request.Gender,
            plot: plot);

        _dbContext.Patients.Add(patient);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new PostPatientResponse(patient.Id);
    }
}