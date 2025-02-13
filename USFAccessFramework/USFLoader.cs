using System;
using System.IO;
using System.Text.Json;

namespace USFAccessFramework
{
    public class USFLoader
    {
        public static USF LoadUSF(string filePath)
        {
            try
            {
                string jsonContent = File.ReadAllText(filePath);
                var usf = JsonSerializer.Deserialize<USF>(jsonContent);
                if (usf == null)
                {
                    throw new InvalidOperationException("Deserialization resulted in a null USF object.");
                }
                return usf;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading USF: {ex.Message}");
                throw new InvalidOperationException("Failed to load USF.");
            }
        }
    }
}
