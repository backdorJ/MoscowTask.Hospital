using Microsoft.EntityFrameworkCore;
using MoscowTask.Core.Entities;

namespace MoscowTask.Core.Abstractions;

/// <summary>
/// Контекст БД
/// </summary>
public interface IDbContext
{
    /// <summary>
    /// Врачи
    /// </summary>
    public DbSet<Doctor> Doctors { get; }

    /// <summary>
    /// Кабинеты
    /// </summary>
    public DbSet<Office> Offices { get; }

    /// <summary>
    /// Пациенты
    /// </summary>
    public DbSet<Patient> Patients { get; }

    /// <summary>
    /// Участки
    /// </summary>
    public DbSet<Plot> Plots { get; }

    /// <summary>
    /// Специализация
    /// </summary>
    public DbSet<Specialization> Specializations { get; }

    /// <summary>
    /// Метод сохранения
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Кол-во затронутых сущностей</returns>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

public interface IDbContext<TEntity>
    where TEntity : class
{
    DbSet<TEntity> Entities { get; set; } 
}