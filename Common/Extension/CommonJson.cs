using System.Text.Json;

namespace Common
{
    public static class CommonJson
    {
        public static T Deserialize<T>(this string jsonString)
        {
            if(string.IsNullOrWhiteSpace(jsonString))
                return default;
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<T>(jsonString, options);
        }
        public static string Serialize(this object obj)
        {
            if (obj == null)
                return null;
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Serialize(obj, options);
        }
    }
}