namespace GuessTheNumber.Interfaces;

/// <summary>
/// Interface declare service contract of Guess service.
/// </summary>
public interface IGuessService
{
    /// <summary>
    /// Method provide logic of guessing number for user.
    /// </summary>
    public void TryGuess();
}