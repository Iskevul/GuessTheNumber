using GuessTheNumber.Abstraction;

namespace GuessTheNumber.Implementation
{
    public class EditSettingsService : ISettingsService
    {
        private readonly Settings _settings;
        private readonly ISettingsRepository _repository;

        public EditSettingsService(Settings settings, SettingsRepository settingsRepository)
        {
            _settings = settings;
            _repository = settingsRepository;
        }

        public void EditSettings()
        {
            while (true)
            {
                Console.WriteLine($"Enter \"1\" for change number of attempts \n" +
                                  $"Enter \"2\" for change range of numbers \n" +
                                  $"Enter \"3\" for exit settings");

                var answer = Console.ReadLine();

                if (answer.Equals("1"))
                    SetNumberOfAttempts();
                else if (answer.Equals("2"))
                    SetRange();
                else if (answer.Equals("3"))
                {
                    if (!_repository.SaveSettings(_settings, "Settings.json", out var errorMessage))
                        Console.WriteLine(errorMessage);

                    return;
                }

                Console.Clear();
            }
        }

        public void SetRange()
        {
            while(true)
            {
                Console.WriteLine("Enter 2 numbers separated by a space");

                var answer = Console.ReadLine();

                if (answer == null)
                {
                    Console.WriteLine("Error. Try again");
                    continue;
                }

                var splittedArray = answer.Split(' ');

                if (splittedArray.Length != 2)
                {
                    Console.WriteLine("Entered not 2 numbers. Try again");
                    continue;
                }

                if (!TryParse(splittedArray, out var range))
                {
                    Console.WriteLine("Convertation error. Try again");
                    continue;
                }

                _settings.Range = new(range[0], range[1]);

                return;
            }
        }

        public void SetNumberOfAttempts()
        {
            while(true)
            {
                Console.WriteLine("Enter the required number of attempts:");

                var enteredString = Console.ReadLine();

                if (int.TryParse(enteredString, out var numberOfAttemts))
                {
                    _settings.NumberOfAttempts = numberOfAttemts;
                    return;
                }
                else
                {
                    Console.WriteLine("Incorrect number. Try again");
                }
            }
        }

        private static bool TryParse(string[] rangeString, out int[] range)
        {
            range = new int[2];
            for (int i = 0; i < rangeString.Length; i++)
            {
                if (!int.TryParse(rangeString[i], out range[i]))
                {
                    return false;
                }
            }

            range = range.OrderBy(x => x).ToArray();

            return true;
        }
    }
}
