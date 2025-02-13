using System.Text.Json;

namespace USFAccessFramework
{
    public class USFGenerator
    {
        public static string GenerateUSF(USF usf)
        {
            try
            {
                var json = JsonSerializer.Serialize(usf, new JsonSerializerOptions { WriteIndented = true });
                return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating USF JSON: {ex.Message}");
                return "{}";
            }
        }
    }
}
