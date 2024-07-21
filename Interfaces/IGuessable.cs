namespace GuessTheNumber.Interfaces;

/// <summary>
/// Interface provide checking answer functionality.
/// </summary>
public interface IGuessable
{
    /// <summary>
    /// Method for checking player answer.
    /// </summary>
    /// <param name="answer">Player answer.</param>
    /// <param name="advise">Output parameter with advise to player.</param>
    /// <returns>True if player answer is right, False (with advise) if not right.</returns>
    public bool CheckAnswer(int answer, out string? advise);

    /// <summary>
    /// Method return minimal border to generate number.
    /// </summary>
    /// <returns>Int32.</returns>
    public int GetMinValue();

    /// <summary>
    /// Method return maximal border to generate number.
    /// </summary>
    /// <returns>Int32./returns>
    public int GetMaxValue();
}
