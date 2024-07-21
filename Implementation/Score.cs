using GuessTheNumber.Exceptions;
using GuessTheNumber.Interfaces;
using Microsoft.Extensions.Configuration;

namespace GuessTheNumber.Implementation;

/// <summary>
/// Class implement score calculation logic.
/// </summary>
public class Score : IScorable
{
    private uint _attempt;

    /// <summary>
    /// Initializes a new instance of the <see cref="Score"/> class.
    /// </summary>
    /// <param name="configuration">Host configuration.</param>
    public Score(IConfiguration configuration)
    {
        _attempt = 0;
        MaxAttempts = Convert.ToUInt32(configuration["MaxAttempt"]);
    }

    /// <summary>
    /// Max attempts count (from configuration).
    /// </summary>
    public uint MaxAttempts { get; }

    /// <summary>
    /// Return actual score.
    /// </summary>
    /// <returns>String with actual score.</returns>
    public string GetScore()
    {
        return string.Format("Used attempts: {0}", _attempt);
    }

    /// <summary>
    /// Method increase attempts counter.
    /// </summary>
    /// <exception cref="MaxAttemptReached">If attempt great than configured count in MaxAttempts application setting.</exception>
    public void NewAttempt()
    {
        if (_attempt > MaxAttempts)
        {
            throw new MaxAttemptReached();
        }

        _attempt++;
    }
}
