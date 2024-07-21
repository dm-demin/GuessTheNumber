namespace GuessTheNumber.Interfaces;

/// <summary>
/// Interface provide score rating calculation.
/// </summary>
public interface IScorable
{
    /// <summary>
    /// public readonly property with maximum attempts number from configuration.
    /// </summary>
    public uint MaxAttempts { get; }

    /// <summary>
    /// Method to increase attempt count;
    /// </summary>
    public void NewAttempt();

    /// <summary>
    /// Method to return calculated score.
    /// </summary>
    /// <returns>Sting with score result</returns>
    public string GetScore();
}
