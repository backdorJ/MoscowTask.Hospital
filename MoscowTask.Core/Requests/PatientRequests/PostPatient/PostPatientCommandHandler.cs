using MediatR;
using Microsoft.EntityFrameworkCore;
using MoscowTask.Contracts.Requests;
using MoscowTask.Core.Abstractions;
using MoscowTask.Core.Entities;
using MoscowTask.Core.Exceptions;

namespace MoscowTask.Core.Requests.PatientRequests.PostPatient;

/// <summary>
/// Обработчик для <see cref="PostPatientCommand"/>
/// </summary>
public class PostPatientCommandHandler : CommandHandlerBase<PostPatientCommand, BasePostResponse>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public PostPatientCommandHandler(IDbContext dbContext)
        => _dbContext = dbContext;

    /// <inheritdoc />
    protected override async Task<BasePostResponse> GetResponse(
        PostPatientCommand command,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command.CommandRequest);
        var request = command.CommandRequest;
        
        var plot = await _dbContext.Plots
            .FirstOrDefaultAsync(x => x.Id == request.PlotId, cancellationToken)
            ?? throw new EntityNotFoundException<Plot>(request.PlotId);

        var patient = new Patient(
            surname: request.Surname,
            name: request.Name,
            address: request.Address,
            birthday: request.Birthday,
            gender: request.Gender,
            plot: plot);

        _dbContext.Patients.Add(patient);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new BasePostResponse(patient.Id);
    }
}