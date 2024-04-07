namespace GuessTheNumber;

public class Settings
{
    public int NumberOfAttempts { get; set; } = 5;

    public Tuple<int, int> Range { get; set; } = new(0, 100);
}
