using MoscowTask.Contracts.Constants;

namespace MoscowTask.Contracts.DoctorsRequests.GetDoctors;

/// <summary>
/// Запрос на получение докторов
/// </summary>
public class GetDoctorsRequest
{
    private int _pageNumber;
    private int _pageSize;
    private string _orderBy;

    public GetDoctorsRequest()
    {
        _pageNumber = PaginationDefaults.PageNumber;
        _pageSize = PaginationDefaults.PageSize;
        _orderBy = nameof(GetDoctorsResponseItem.Name);
    }

    /// <summary>
    /// Номер страницы
    /// </summary>
    public int PageNumber
    {
        get => _pageNumber;
        set => _pageNumber = value > 0
            ? value
            : PaginationDefaults.PageNumber;
    }
    
    /// <summary>
    /// Кол-во элементов на странице
    /// </summary>
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > 0
            ? value
            : PaginationDefaults.PageSize;
    }

    /// <summary>
    /// Сортировка по полю
    /// </summary>
    public string? OrderBy
    {
        get => _orderBy;
        set => _orderBy = string.IsNullOrWhiteSpace(value)
            ? nameof(GetDoctorsResponseItem.Name)
            : value;
    }

    /// <summary>
    /// По возрастанию
    /// </summary>
    public bool IsAscending { get; set; }
}