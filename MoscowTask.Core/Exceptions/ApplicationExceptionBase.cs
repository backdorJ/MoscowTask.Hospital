namespace MoscowTask.Core.Exceptions;

/// <summary>
/// Базовая ошибка приложения
/// </summary>
public class ApplicationExceptionBase : Exception
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    public ApplicationExceptionBase(string message)
        : base(message)
    {
    }
}