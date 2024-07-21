using GuessTheNumber.Abstractions;
using Microsoft.Extensions.Configuration;

namespace GuessTheNumber.Implementation;

/// <summary>
/// Type to storing thinked number. Realize simple randomize algorithm.
/// </summary>
public class ThinkRandom : ThinkBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ThinkRandom"/> class.
    /// </summary>
    /// <param name="configuration">Host configuration parameters</param>
    public ThinkRandom(IConfiguration configuration)
    {
        var rnd = new Random();
        _minValue = Convert.ToInt32(configuration["RandomMinValue"]);
        _maxValue = Convert.ToInt32(configuration["RandomMaxValue"]);

        _hiddenValue = rnd.Next(_minValue, _maxValue);
    }
}
