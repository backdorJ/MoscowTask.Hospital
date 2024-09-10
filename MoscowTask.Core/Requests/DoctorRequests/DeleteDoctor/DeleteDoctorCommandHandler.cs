using MediatR;
using Microsoft.EntityFrameworkCore;
using MoscowTask.Core.Abstractions;
using MoscowTask.Core.Entities;
using MoscowTask.Core.Exceptions;

namespace MoscowTask.Core.Requests.DoctorRequests.DeleteDoctor;

/// <summary>
/// Обработчик для <see cref="DeleteDoctorCommand"/>
/// </summary>
public class DeleteDoctorCommandHandler : CommandHandlerBase<DeleteDoctorCommand, Unit>
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public DeleteDoctorCommandHandler(IDbContext dbContext)
        => _dbContext = dbContext;

    /// <inheritdoc />
    protected override async Task<Unit> GetResponse(DeleteDoctorCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command.Id);
        
        var doctor = await _dbContext.Doctors
            .FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken)
            ?? throw new EntityNotFoundException<Doctor>(command.Id.Value);

        _dbContext.Doctors.Remove(doctor);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return default!;
    }
}