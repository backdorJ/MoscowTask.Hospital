namespace MoscowTask.Core.Entities;

/// <summary>
/// Кабинет
/// </summary>
public class Office : EntityBase
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="number">Номер</param>
    /// <param name="doctors">Врачи</param>
    public Office(
        string number,
        List<Doctor>? doctors = default)
    {
        Number = number;
        Doctors = doctors ?? new List<Doctor>();
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    private Office()
    {
    }
    
    /// <summary>
    /// Номер
    /// </summary>
    public string Number { get; set; } = default!;

    #region Navigation Properties

    /// <summary>
    /// Врачи
    /// </summary>
    public List<Doctor>? Doctors { get; }

    #endregion
}