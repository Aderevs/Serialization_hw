using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task5
{
    public class CustomSafeDateTimeConverter : JsonConverter<DateOnly?>
    {

        public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var valueString = reader.GetString();
            if (valueString is null)
                return null;
            if (!DateOnly.TryParse(valueString, out var dateTime))
            {
                return null;
            }
            return dateTime;
        }

        public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value?.ToString(
                     "MM/dd/yyyy", CultureInfo.InvariantCulture));
        }
    }
    public partial class CustomSafeEmailConverter : JsonConverter<string?>
    {
        public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var email = reader.GetString();
            if (email is null)
                return null;
            var EmailChecker = CheckEmail();
            if (EmailChecker.IsMatch(email))
            {
                return email;
            }
            return null;
        }

        public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
        
        
        [GeneratedRegex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$")]
        public partial Regex CheckEmail();
    }
    internal class User
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        [JsonConverter(typeof(CustomSafeEmailConverter))]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("username")]
        public string Usermane {  get; set; }

        [JsonPropertyName("date_of_registration")]
        [JsonConverter(typeof(CustomSafeDateTimeConverter))]
        public DateOnly? DateOfRegistration { get; set; }
    
        
    }
}
