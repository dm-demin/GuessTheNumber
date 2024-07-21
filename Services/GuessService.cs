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

    /// <summary>
    /// Initializes a new instance of the <see cref="GuessService"/> class.
    /// </summary>
    /// <param name="score">Scope calculation class.</param>
    /// <param name="hiddenNumber">Hidden number class.</param>
    public GuessService(IScorable score, IGuessable hiddenNumber)
    {
        _score = score;
        _hiddenNumber = hiddenNumber;
    }

    /// <inheritdoc/>
    public void TryGuess()
    {
        Console.WriteLine("Try to guess number between {0} and {1}", _hiddenNumber.GetMinValue(), _hiddenNumber.GetMaxValue());
        Console.WriteLine("You have {0} attempts", _score.MaxAttempts);
        try
        {
            while (true)
            {
                _score.NewAttempt();

                Console.Write("Your answer: ");
                int answer = Convert.ToInt32(Console.ReadLine());

                var isRight = _hiddenNumber.CheckAnswer(answer, out var advise);
                Console.WriteLine(advise);
                if (isRight)
                {
                    break;
                }
            }

            Console.WriteLine(_score.GetScore());
        }
        catch (MaxAttemptReached)
        {
            Console.WriteLine("Max attempt reached, try again later...");
        }

        return;
    }
}
