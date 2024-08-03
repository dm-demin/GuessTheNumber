using GuessTheNumber.Interfaces;

namespace GuessTheNumber.Implementation;

/// <summary>
/// Realization of IUserCommunicate interface for command line.
/// </summary>
public class ConsoleUserCommunicator : IUserCommunicate
{
    /// <summary>
    /// Print to console messages for user.
    /// </summary>
    /// <param name="notification">notification string.</param>
    public void Notify(string? notification)
    {
        if (notification is null)
        {
            return;
        }

        Console.WriteLine(notification);
    }

    /// <summary>
    /// Method wait and return user answer from console.
    /// </summary>
    /// <returns>Answered number.</returns>
    public int WaitAnswer()
    {
        int number;
        Console.Write("Your answer: ");
        var answer = Console.ReadLine();

        while (!int.TryParse(answer, out number))
        {
            Console.WriteLine("Your answer is not a number!");
            Console.Write("Try again: ");
            answer = Console.ReadLine();
        }

        return number;
    }
}
