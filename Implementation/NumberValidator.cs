using GuessTheNumber.Abstraction;

namespace GuessTheNumber.Implementation;

public class NumberValidator : INumberValidator
{
    public bool CheckNumber(int secretNumber, int enteredNumber, out string message)
    {
        if (enteredNumber < secretNumber)
        {
            message = "The entered number is less than the secret number";
            return false;
        }
        else if (enteredNumber > secretNumber)
        {
            message = "The entered number is more than the secret number";
            return false;
        }
        else
        {
            message = "Congratulations! You guessed the number!";
            return true;
        }
    }
}