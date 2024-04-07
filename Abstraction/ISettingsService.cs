

namespace GuessTheNumber.Abstraction
{
    public interface ISettingsService
    {
        void SetRange();
        void SetNumberOfAttempts();
        void EditSettings();
    }
}
