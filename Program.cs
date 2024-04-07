using GuessTheNumber.Implementation;

namespace GuessTheNumber
{
    public class Program
    {
        static void Main(string[] args)
        {
            var settingsRepository = new SettingsRepository();
            var settings = settingsRepository.ReadSettings("Settings.json");
            var editSettingsService = new EditSettingsService(settings, settingsRepository);
            var readLine = string.Empty;
            while (true)
            {
                Console.Write("Enter \"1\" to start the game, \"2\" to open settings or \"3\" to exit: ");
                readLine = Console.ReadLine();
                if (string.Equals(readLine, "1", StringComparison.OrdinalIgnoreCase))
                {
                    var generator = new NumberGenerator(settings);
                    var validator = new NumberValidator();
                    var game = new Game(settings, validator, generator);
                    game.StartGame();
                }
                else if (string.Equals(readLine, "2", StringComparison.OrdinalIgnoreCase))
                {
                    editSettingsService.EditSettings();
                }
                else if (string.Equals(readLine, "3", StringComparison.OrdinalIgnoreCase))
                    return;

                Console.WriteLine("\n");
            }
        }
    }
}
