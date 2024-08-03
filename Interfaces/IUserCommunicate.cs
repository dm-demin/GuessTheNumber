namespace GuessTheNumber.Interfaces;

/// <summary>
/// Interface provide user interface actions
/// </summary>
public interface IUserCommunicate
{
    /// <summary>
    /// Method for user notifications.
    /// </summary>
    public void Notify(string? notification);

    /// <summary>
    /// Method provide communications about new attempt to guess
    /// </summary>
    /// <returns>User answered number</returns>
    public int WaitAnswer();
}
