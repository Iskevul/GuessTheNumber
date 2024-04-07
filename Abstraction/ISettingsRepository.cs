
namespace GuessTheNumber.Abstraction
{
    public interface ISettingsRepository
    {
        bool SaveSettings(Settings settings, string path, out string errorMessage);
        Settings ReadSettings(string path);
    }
}