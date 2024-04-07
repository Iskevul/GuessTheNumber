using GuessTheNumber.Abstraction;

namespace GuessTheNumber.Implementation;

public class NumberGenerator : INumberGenerator
{
    private readonly Settings _settings;

    public NumberGenerator(Settings settings)
    {
        _settings = settings;
    }

    public int GenerateNumber()
    {
        var random = new Random();
        var generatedNumber = random.Next(_settings.Range.Item1, _settings.Range.Item2);
        return generatedNumber;
    }
}