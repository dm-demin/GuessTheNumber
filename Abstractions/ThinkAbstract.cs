using GuessTheNumber.Interfaces;

namespace GuessTheNumber.Abstractions;

public abstract class ThinkBase : IGuessable
{
    #pragma warning disable SA1401
    protected int _hiddenValue;

    protected int _minValue;
    protected int _maxValue;
    #pragma warning restore SA1401

    public bool CheckAnswer(int answer, out string? advise)
    {
        advise = string.Empty;
        if (answer == _hiddenValue)
        {
            advise = "You are right!";
            return true;
        }

        if (answer < _hiddenValue)
        {
            advise = "You number is less than thinked.";
        }

        if (answer > _hiddenValue)
        {
            advise = "You number is great than thinked.";
        }

        return false;
    }

    public int GetMinValue() => _minValue;

    public int GetMaxValue() => _maxValue;
}
