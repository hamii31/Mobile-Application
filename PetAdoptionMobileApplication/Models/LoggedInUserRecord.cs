using System.Text.Json;

namespace PetAdoptionMobileApplication.Models
{
    public record LoggedInUserRecord(Guid Id, string Name, string Token)
    {
        public string ToJSON() => JsonSerializer.Serialize(this);

        public static LoggedInUserRecord FromJSON(string? json) => !string.IsNullOrWhiteSpace(json) 
                                                                   ? JsonSerializer.Deserialize<LoggedInUserRecord>(json) // if json is not null do this
                                                                   : default; // else
    };
}
