using MediatR;
using Microsoft.EntityFrameworkCore;
using MoscowTask.Core.Abstractions;

namespace MoscowTask.Core.Requests.DoctorRequests.DeleteDoctor;

/// <summary>
/// Обработчик для <see cref="DeleteDoctorCommand"/>
/// </summary>
public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public DeleteDoctorCommandHandler(IDbContext dbContext)
        => _dbContext = dbContext;

    /// <inheritdoc />
    public async Task Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        
        var doctor = await _dbContext.Doctors
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new ArgumentNullException(nameof(request.Id));

        _dbContext.Doctors.Remove(doctor);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}