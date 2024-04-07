
namespace GuessTheNumber.Abstraction
{
    public interface INumberValidator
    {
        bool CheckNumber(int secretNumber, int enteredNumber, out string message);
    }
}