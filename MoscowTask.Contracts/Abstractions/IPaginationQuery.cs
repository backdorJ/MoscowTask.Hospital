namespace MoscowTask.Core.Abstractions;

/// <summary>
/// Интерфейс для пагинируемых запросов
/// </summary>
public interface IPaginationQuery
{
    /// <summary>
    /// Номер страницы
    /// </summary>
    int PageNumber { get; set; }
    
    /// <summary>
    /// Кол-во элементов на странице
    /// </summary>
    int PageSize { get; set; }
}