namespace MoscowTask.Core.Abstractions;

public interface IOrderByQuery
{
    /// <summary>
    /// Поле, по которому применяется сортировка
    /// </summary>
    string? OrderBy { get; }

    /// <summary>
    /// По возрастанию или убыванию
    /// </summary>
    bool IsAscending { get; }
}