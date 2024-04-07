using GuessTheNumber.Abstraction;
using Newtonsoft.Json;

namespace GuessTheNumber.Implementation;

public class SettingsRepository : ISettingsRepository
{
    public Settings ReadSettings(string path)
    {
        if (!Path.Exists(path)) 
            return new Settings();

        var json = File.ReadAllText(path);
        var settings = JsonConvert.DeserializeObject<Settings>(json);
        return settings ?? new Settings();
    }

    public bool SaveSettings(Settings settings, string path, out string errorMessage)
    {
        errorMessage = string.Empty;
        var json = JsonConvert.SerializeObject(settings);
        if (string.IsNullOrWhiteSpace(json))
        {
            errorMessage = "Settings deserealiation error";
            return false;
        }

        try
        {
            File.WriteAllText(path, json);
            return true;
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
            return false;
        }
    }
}