using Microsoft.EntityFrameworkCore;
using MoscowTask.Core.Abstractions;
using MoscowTask.Core.Entities;

namespace MoscowTask.DAL.MS;

/// <summary>
/// Входная точка контекста БД
/// </summary>
public class EfContext : DbContext, IDbContext
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="options">Настройки</param>
    public EfContext(DbContextOptions<EfContext> options)
        : base(options)
    {
    }
    
    /// <inheritdoc />
    public DbSet<Doctor> Doctors { get; set; }

    /// <inheritdoc />
    public DbSet<Office> Offices { get; set; }

    /// <inheritdoc />
    public DbSet<Patient> Patients { get; set; }

    /// <inheritdoc />
    public DbSet<Plot> Plots { get; set; }

    /// <inheritdoc />
    public DbSet<Specialization> Specializations { get; set; }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EfContext).Assembly);
    }
}