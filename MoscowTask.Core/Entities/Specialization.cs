namespace MoscowTask.Core.Entities;

/// <summary>
/// Специализация
/// </summary>
public class Specialization : EntityBase
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name">Название</param>
    public Specialization(string name)
    {
        Name = name;
        Doctors = new();
    }

    private Specialization()
    {
    }
    
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; } = default!;

    #region Navigation Properties

    /// <summary>
    /// Врачи
    /// </summary>
    public List<Doctor>? Doctors { get; }

    #endregion
}