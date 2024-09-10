using Microsoft.EntityFrameworkCore;
using MoscowTask.Contracts.Requests;
using MoscowTask.Core.Abstractions;
using MoscowTask.Core.Entities;
using MoscowTask.Core.Exceptions;

namespace MoscowTask.Core.Requests.DoctorRequests.PostDoctor;

/// <summary>
/// Обработчик для <see cref="PostDoctorCommand"/>
/// </summary>
public class PostDoctorCommandHandler : CommandHandlerBase<PostDoctorCommand, BasePostResponse>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public PostDoctorCommandHandler(IDbContext dbContext)
        => _dbContext = dbContext;

    /// <inheritdoc />
    protected override async Task<BasePostResponse> GetResponse(
        PostDoctorCommand command,
        CancellationToken cancellationToken)
    {
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

        var doctor = new Doctor(
            surname: request.Surname,
            name: request.Name,
            patronymic: request.Patronymic,
            office: office,
            specialization: specialization,
            plot: plot);

        _dbContext.Doctors.Add(doctor);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new BasePostResponse(doctor.Id);
    }
}