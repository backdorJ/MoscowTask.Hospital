using System.Linq.Expressions;
using MoscowTask.Core.Abstractions;

namespace MoscowTask.Core.QueryableExtensions;

/// <summary>
/// Расширения для <see cref="IQueryable{T}"/>
/// </summary>
public static class QueryableExtension
{
    /// <summary>
    /// Применить пагинацию к запросу
    /// </summary>
    /// <param name="query">Запрос</param>
    /// <param name="paginationFilter">Фильтр</param>
    /// <returns>Кол-во сущностей</returns>
    public static IQueryable<TEntity> SkipTake<TEntity>(
        this IQueryable<TEntity> query,
        IPaginationQuery paginationFilter)
    {
        if (query is null)
            throw new ArgumentNullException(nameof(query));

        return query
            .Skip((paginationFilter.PageNumber - 1) * paginationFilter.PageSize)
            .Take(paginationFilter.PageSize);
    }

    /// <summary>
    /// Применить сортировку
    /// <see cref="IPaginationQuery"/>
    /// </summary>
    /// <typeparam name="T">Тип IQueryable</typeparam>
    /// <param name="queryable">IQueryable</param>
    /// <param name="orderBy">Сортировка</param>
    /// <returns>IQueryable с сортировкой</returns>
    public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> queryable, IOrderByQuery orderBy)
    {
        ArgumentNullException.ThrowIfNull(queryable);

        if (string.IsNullOrWhiteSpace(orderBy?.OrderBy))
            return queryable.OrderBy(x => 0);

        return queryable.OrderByField(orderBy.OrderBy, orderBy.IsAscending);
    }
    
    /// <summary>
    /// Сортировать по полю, указанному в текстовом виде
    /// Стащено отсюда: https://stackoverflow.com/a/22227975
    /// </summary>
    /// <typeparam name="T">Тип сущностей IQueryable</typeparam>
    /// <param name="queryable">IQueryable</param>
    /// <param name="propertyName">Поле для сортировки</param>
    /// <param name="isAscending">По возрастанию ли</param>
    /// <returns>IQueryable отсортированный</returns>
    public static IOrderedQueryable<T> OrderByField<T>(this IQueryable<T> queryable, string propertyName, bool isAscending = true)
    {
        ArgumentNullException.ThrowIfNull(queryable);

        if (string.IsNullOrWhiteSpace(propertyName))
            throw new ArgumentNullException(nameof(propertyName));

        var param = Expression.Parameter(queryable.ElementType, "p");
        var prop = (Expression)param;
        foreach (var property in propertyName.Split('.'))
            prop = ExtractProperty(prop, property);

        var exp = Expression.Lambda(prop, param);
        var method = isAscending ? nameof(Queryable.OrderBy) : nameof(Queryable.OrderByDescending);

        // PostgreSQL сортирует DateTime? через NULL FIRST по умолчанию, в какую бы сторону сортировка ни шла
        if (exp.ReturnType == typeof(DateTime?))
        {
            queryable = queryable.OrderByHasValue(propertyName, false);
            method = isAscending ? nameof(Queryable.ThenBy) : nameof(Queryable.ThenByDescending);
        }

        var types = new[] { queryable.ElementType, exp.Body.Type };
        var mce = Expression.Call(typeof(Queryable), method, types, queryable.Expression, exp);
#pragma warning disable CS8603 // Possible null reference return.
        return queryable.Provider.CreateQuery<T>(mce) as IOrderedQueryable<T>;
#pragma warning restore CS8603 // Possible null reference return.
    }
    
    /// <summary>
    /// Сортировать по наличию свойства
    /// Стащено отсюда: https://stackoverflow.com/a/22227975
    /// </summary>
    /// <typeparam name="T">Тип сущностей IQueryable</typeparam>
    /// <param name="queryable">IQueryable</param>
    /// <param name="propertyName">Поле для сортировки</param>
    /// <param name="isAscending">По возрастанию ли</param>
    /// <returns>IQueryable отсортированный</returns>
    // ReSharper disable once SuggestBaseTypeForParameter
    private static IOrderedQueryable<T> OrderByHasValue<T>(this IQueryable<T> queryable, string propertyName, bool isAscending = true)
    {
        if (queryable == null)
            throw new ArgumentNullException(nameof(queryable));

        if (string.IsNullOrWhiteSpace(propertyName))
            throw new ArgumentNullException(nameof(propertyName));

        var param = Expression.Parameter(typeof(T), "p");
        var prop = (Expression)param;
        foreach (var property in propertyName.Split('.'))
            prop = ExtractProperty(prop, property);
        prop = Expression.Property(prop, "HasValue");

        var exp = Expression.Lambda(prop, param);
        var method = isAscending ? "OrderBy" : "OrderByDescending";
        var types = new[] { queryable.ElementType, exp.Body.Type };
        var mce = Expression.Call(typeof(Queryable), method, types, queryable.Expression, exp);
#pragma warning disable CS8603 // Possible null reference return.
        return queryable.Provider.CreateQuery<T>(mce) as IOrderedQueryable<T>;
#pragma warning restore CS8603 // Possible null reference return.
    }
    
    /// <summary>
    /// Применить название свойства к выражению доступа к свойству
    /// </summary>
    /// <param name="expression">Выражение доступа к свойству</param>
    /// <param name="property">Свойство</param>
    /// <exception cref="InvalidOrderByExpressionException">Если не удалось преобразовать к свойству или полю</exception>
    /// <returns>Выражение со свойством или полем или исключение</returns>
    private static Expression ExtractProperty(Expression expression, string property)
    {
        try
        {
            return Expression.PropertyOrField(expression, property);
        }
        catch (ArgumentException)
        {
            throw new InvalidOperationException();
        }
    }
}