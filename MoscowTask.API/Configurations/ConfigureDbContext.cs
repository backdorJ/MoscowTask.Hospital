using Microsoft.EntityFrameworkCore;
using MoscowTask.Core.Abstractions;
using MoscowTask.DAL.MS;

namespace MoscowTask.API.Configurations;

/// <summary>
/// Конфигурация базы данных
/// </summary>
public static class ConfigureDbContext
{
    /// <summary>
    /// Добавить сконфигурированную БД
    /// </summary>
    /// <param name="services">Сервисы</param>
    /// <param name="conf">Конфигурация</param>
    public static void ConfigureCustomDbContext(this IServiceCollection services, IConfiguration conf)
    {
        services.AddDbContext<IDbContext, EfContext>(
            options => options.UseSqlServer(conf.GetConnectionString("MSSql_Connection")));
    }
}