using MediatR;
using Microsoft.EntityFrameworkCore;
using MoscowTask.Contracts.DoctorsRequests.PostDoctor;
using MoscowTask.Core.Abstractions;
using MoscowTask.Core.Entities;

namespace MoscowTask.Core.Requests.DoctorRequests.PostDoctor;

/// <summary>
/// Обработчик для <see cref="PostDoctorCommand"/>
/// </summary>
public class PostDoctorCommandHandler : IRequestHandler<PostDoctorCommand, PostDoctorResponse>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public PostDoctorCommandHandler(IDbContext dbContext)
        => _dbContext = dbContext;

    /// <inheritdoc />
    public async Task<PostDoctorResponse> Handle(PostDoctorCommand request, CancellationToken cancellationToken)
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

        var doctor = new Doctor(
            surname: request.Surname,
            name: request.Name,
            patronymic: request.Patronymic,
            office: office,
            specialization: specialization,
            plot: plot);

        _dbContext.Doctors.Add(doctor);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new PostDoctorResponse(doctor.Id);
    }
}