using System.IO;

namespace USFAccessFramework
{
    public class USFWriter
    {
        public static void SaveUSF(USF usf, string filePath)
        {
            try
            {
                var jsonContent = USFGenerator.GenerateUSF(usf);
                File.WriteAllText(filePath, jsonContent);
                Console.WriteLine("USF file saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving USF file: {ex.Message}");
            }
        }
    }
}
