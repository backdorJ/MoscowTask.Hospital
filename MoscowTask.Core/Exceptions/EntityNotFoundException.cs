using MoscowTask.Core.Entities;

namespace MoscowTask.Core.Exceptions;

/// <summary>
/// Ошибка об отсутствии сущности
/// </summary>
public class EntityNotFoundException<TEntity> : ApplicationException
    where TEntity : EntityBase
{
    private static readonly IDictionary<Type, string> Entities = new Dictionary<Type, string>()
    {
        [typeof(Doctor)] = "Не найдены доктора",
        [typeof(Patient)] = "Не найдены пациенты",
        [typeof(Office)] = "Не найдены кабинеты",
        [typeof(Plot)] = "Не найдены участки",
        [typeof(Specialization)] = "Не найдены специализации"
    };
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор</param>
    public EntityNotFoundException(Guid id)
        : base($"{EntityName} с идентификатором {id}")
    {
    }

    private static string EntityName => Entities[typeof(TEntity)] ?? typeof(TEntity).Name;
}