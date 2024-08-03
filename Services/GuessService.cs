using GuessTheNumber.Exceptions;
using GuessTheNumber.Interfaces;

namespace GuessTheNumber.Services;

/// <summary>
/// Service provide guessing logic for user.
/// </summary>
public class GuessService : IGuessService
{
    private readonly IScorable _score;
    private readonly IGuessable _hiddenNumber;

    private readonly IUserCommunicate _userInterface;

    /// <summary>
    /// Initializes a new instance of the <see cref="GuessService"/> class.
    /// </summary>
    /// <param name="score">Scope calculation class.</param>
    /// <param name="hiddenNumber">Hidden number class.</param>
    public GuessService(IScorable score, IGuessable hiddenNumber, IUserCommunicate userInterface)
    {
        _score = score;
        _hiddenNumber = hiddenNumber;
        _userInterface = userInterface;
    }

    /// <inheritdoc/>
    public void TryGuess()
    {
        _userInterface.Notify(string.Format("Try to guess number between {0} and {1}", _hiddenNumber.GetMinValue(), _hiddenNumber.GetMaxValue()));
        _userInterface.Notify(string.Format("You have {0} attempts", _score.MaxAttempts));
        try
        {
            while (true)
            {
                _score.NewAttempt();

                int answer = _userInterface.WaitAnswer();
                var isRight = _hiddenNumber.CheckAnswer(answer, out var advise);
                _userInterface.Notify(advise);
                if (isRight)
                {
                    break;
                }
            }

            _userInterface.Notify(string.Format(_score.GetScore()));
        }
        catch (MaxAttemptReached)
        {
            _userInterface.Notify(string.Format("Max attempt reached, try again later..."));
        }

        return;
    }
}
