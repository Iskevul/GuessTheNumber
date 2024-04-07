using GuessTheNumber.Abstraction;

namespace GuessTheNumber.Implementation
{
    public class Game : IGame
    {
        private readonly Settings _settings;
        private readonly INumberValidator _numberValidator;
        private readonly INumberGenerator _numberGenerator;

        public Game(Settings settings, INumberValidator numberValidator, INumberGenerator numberGenerator)
        {
            _settings = settings;
            _numberValidator = numberValidator;
            _numberGenerator = numberGenerator;
        }

        public void StartGame()
        {
            Console.WriteLine($"Guess the number from {_settings.Range.Item1} to {_settings.Range.Item2}");

            var secretNumber = _numberGenerator.GenerateNumber();
            var attempts = _settings.NumberOfAttempts;

            while (attempts > 0)
            {
                Console.WriteLine($"{attempts} attempts left.");
                Console.WriteLine($"Enter the number or \"c\" to end game");
                var answer = Console.ReadLine();

                if (answer.ToLower().Equals("c"))
                {
                    Console.WriteLine($"Secret number is {secretNumber}");
                    return;
                }

                if (!int.TryParse(answer, out var enteredNumber))
                    Console.WriteLine("Incorrect number. Try again");
                else
                {
                    var result = _numberValidator.CheckNumber(secretNumber, enteredNumber, out var message);
                    Console.WriteLine(message);

                    if (result)
                        return;
                    attempts--;
                }

                Console.Clear();
            }

            Console.WriteLine($"You didn't guess the secret number. It was {secretNumber}");
        }
    }
}
