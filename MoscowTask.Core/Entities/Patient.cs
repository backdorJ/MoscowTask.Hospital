using MoscowTask.Contracts.Enums;

namespace MoscowTask.Core.Entities;

/// <summary>
/// Пациент
/// </summary>
public class Patient : EntityBase
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="surname">Фамилия</param>
    /// <param name="name">Имя</param>
    /// <param name="address">Адрес</param>
    /// <param name="birthday">Дата рождения</param>
    /// <param name="gender">Пол</param>
    /// <param name="plot">Участок</param>
    public Patient(
        string surname,
        string name,
        string address,
        DateOnly birthday,
        Gender gender,
        Plot? plot)
    {
        Surname = surname;
        Name = name;
        Address = address;
        Birthday = birthday;
        Gender = gender;
        Plot = plot;
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    private Patient()
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
    /// Адрес
    /// </summary>
    public string Address { get; set; } = default!;

    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateOnly Birthday { get; set; }

    /// <summary>
    /// Пол
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// Идентификатор участка
    /// </summary>
    public Guid PlotId { get; private set; }

    #region Navigations Properties

    /// <summary>
    /// Участок
    /// </summary>
    public Plot? Plot { get; set; }

    #endregion
}