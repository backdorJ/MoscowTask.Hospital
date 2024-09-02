namespace MoscowTask.Core.Entities;

/// <summary>
/// Доктор
/// </summary>
public class Doctor : EntityBase
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="surname">Фамилия</param>
    /// <param name="name">Имя</param>
    /// <param name="patronymic">Отчество</param>
    /// <param name="office">Кабинет</param>
    /// <param name="specialization">Специализация</param>
    /// <param name="plot">Участок</param>
    public Doctor(
        string surname,
        string name,
        string? patronymic,
        Office? office,
        Specialization? specialization,
        Plot? plot)
    {
        Surname = surname;
        Name = name;
        Patronymic = patronymic;;
        Office = office;
        Specialization = specialization;
        Plot = plot;
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    private Doctor()
    {
    }
    
    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname { get; set; } = default!;

    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Отчество
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// Идентификатор кабинета
    /// </summary>
    public Guid OfficeId { get; private set; }

    /// <summary>
    /// Идентификатор специализации
    /// </summary>
    public Guid SpecializationId { get; private set; }

    /// <summary>
    /// Идентификатор участка
    /// </summary>
    public Guid PlotId { get; private set; }

    #region Navigation Properties

    /// <summary>
    /// Кабинет
    /// </summary>
    public Office? Office { get; set; }

    /// <summary>
    /// Специализация
    /// </summary>
    public Specialization? Specialization { get; set; }

    /// <summary>
    /// Участок
    /// </summary>
    public Plot? Plot { get; set; }
    
    #endregion
}