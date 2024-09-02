using MoscowTask.Core.Abstractions;
using MoscowTask.Core.Entities;

namespace MoscowTask.Core.Services;

/// <summary>
/// Засидить данные в бд
/// </summary>
public class DbSeeder : IDbSeeder
{
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    public DbSeeder(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task SeedAsync()
    {
        await SeedOfficesAsync();
        await SeedPlotsAsync();
        await SeedSpecializationsAsync();
        await _dbContext.SaveChangesAsync(new CancellationToken());
    }

    private async Task SeedOfficesAsync()
        => await _dbContext.Offices.AddRangeAsync(
            new Office("123"),
            new Office("1234"),
            new Office("1235"));

    private async Task SeedPlotsAsync()
        => await _dbContext.Plots.AddRangeAsync(
            new Plot("1"),
            new Plot("2"),
            new Plot("3"));
    
    private async Task SeedSpecializationsAsync()
        => await _dbContext.Specializations.AddRangeAsync(
            new Specialization("Стоматолог"),
            new Specialization("Уролог"),
            new Specialization("Ортодонт"));
}