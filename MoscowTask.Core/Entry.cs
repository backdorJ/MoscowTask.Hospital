using Microsoft.Extensions.DependencyInjection;
using MoscowTask.Core.Abstractions;
using MoscowTask.Core.Services;

namespace MoscowTask.Core;

public static class Entry
{
    public static void AddCore(this IServiceCollection services)
    {
        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(Entry).Assembly));
        services.AddScoped<IDbSeeder, DbSeeder>();
    }
}