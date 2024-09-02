using Microsoft.Extensions.DependencyInjection;

namespace MoscowTask.DAL.MS;

/// <summary>
/// Входная точка DAL уровня
/// </summary>
public static class Entry
{
    /// <summary>
    /// Добавить Dal уровень
    /// </summary>
    /// <param name="services">Сервисы</param>
    public static void AddDal(this IServiceCollection services)
    {
        services.AddTransient<Migrator>();
    }
}