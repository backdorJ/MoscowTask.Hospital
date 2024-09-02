namespace MoscowTask.Core.Entities;

/// <summary>
/// Участок
/// </summary>
public class Plot : EntityBase
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="number">Номер</param>
    public Plot(string number)
    {
        Number = number;
        Patients = new();
        Doctors = new();
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    private Plot()
    {
    }
    
    /// <summary>
    /// Номер
    /// </summary>
    public string Number { get; set; } = default!;

    #region Navigation Properties

    /// <summary>
    /// Пациенты
    /// </summary>
    public List<Patient>? Patients { get; }

    /// <summary>
    /// Врачи
    /// </summary>
    public List<Doctor>? Doctors { get; }

    #endregion
}