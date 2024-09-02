namespace MoscowTask.Core.Abstractions;

/// <summary>
/// Сид данных в бд
/// </summary>
public interface IDbSeeder
{
    /// <summary>
    /// Сид данных
    /// </summary>
    /// <returns>-</returns>
    public Task SeedAsync();
}