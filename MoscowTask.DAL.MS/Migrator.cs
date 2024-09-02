using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoscowTask.Core.Abstractions;

namespace MoscowTask.DAL.MS;

/// <summary>
/// Мигратор
/// </summary>
public class Migrator
{
    private readonly EfContext _efContext;
    private readonly ILogger<Migrator> _logger;
    private readonly IDbSeeder _seeder;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="efContext">Контекст БД</param>
    /// <param name="logger">Логгер</param>
    /// <param name="seeder">Сидер</param>
    public Migrator(EfContext efContext, ILogger<Migrator> logger, IDbSeeder seeder)
    {
        _efContext = efContext;
        _logger = logger;
        _seeder = seeder;
    }

    /// <summary>
    /// Мигрировать
    /// </summary>
    public async Task MigrateAsync()
    {
        try
        {
            var migrationId = Guid.NewGuid();
            _logger.LogInformation($"Начало миграции {migrationId}");
            await _efContext.Database.MigrateAsync();
            await _seeder.SeedAsync();
            _logger.LogInformation($"Конец миграции {migrationId}");
        }
        catch (Exception e)
        {
            _logger.LogCritical($"Миграция прошла повально {e.Message}");
        }
    }
}