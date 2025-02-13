using System;
using System.IO;

namespace USFAccessFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            // 检查是否提供了文件路径
            if (args.Length < 1)
            {
                Console.WriteLine("Please provide the USF file path as an argument.");
                return;
            }

            string filePath = args[0];

            // 1. 检查文件是否存在
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"The file at {filePath} does not exist.");
                return;
            }

            // 2. 加载 USF 文件
            var usf = USFLoader.LoadUSF(filePath);
            if (usf == null)
            {
                Console.WriteLine("Failed to load the USF file.");
                return;
            }

            // 3. 验证 USF 文件是否有效
            if (!USFValidator.IsValidUSF(usf))
            {
                Console.WriteLine("The USF file is not valid.");
                return;
            }

            Console.WriteLine("USF file loaded and validated successfully.");

            // 4. 用户输入：添加新的学科
            Console.WriteLine("Enter the subject name:");
            string subjectName = Console.ReadLine() ?? string.Empty;
            if (subjectName == null)
            {
                Console.WriteLine("Invalid input for subject name.");
                return;
            }

            Console.WriteLine("Enter the simplified name:");
            string simplifiedName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter the teacher's name:");
            string teacher = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Enter the room number:");
            string room = Console.ReadLine() ?? string.Empty;

            // 添加新学科
            USFUpdater.AddSubject(ref usf, subjectName, simplifiedName, teacher, room);
            Console.WriteLine($"Added new subject: {subjectName}");

            // 5. 用户输入：添加新的课程安排
            Console.WriteLine("Enter the day of the week (1 = Monday, 7 = Sunday):");
            if (!int.TryParse(Console.ReadLine(), out int day) || day < 1 || day > 7)
            {
                Console.WriteLine("Invalid day input.");
                return;
            }

            Console.WriteLine("Enter the week type (all, even, odd):");
            string weekType = Console.ReadLine()?.ToLower() ?? string.Empty;
            if (weekType != "all" && weekType != "even" && weekType != "odd")
            {
                Console.WriteLine("Invalid week type input.");
                return;
            }

            Console.WriteLine("Enter the class period number (1, 2, 3, ...):");
            if (!int.TryParse(Console.ReadLine(), out int period) || period < 1)
            {
                Console.WriteLine("Invalid period input.");
                return;
            }

            // 添加课程安排
            USFUpdater.AddTimetableEntry(ref usf, day, weekType, subjectName, period);
            Console.WriteLine($"Added timetable entry for {subjectName} on day {day}, period {period}");

            // 6. 用户输入：保存更新后的 USF 文件
            Console.WriteLine("Enter the path to save the updated USF file:");
            string newFilePath = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(newFilePath))
            {
                Console.WriteLine("Invalid file path.");
                return;
            }

            // 保存更新后的 USF 文件
            USFWriter.SaveUSF(usf, newFilePath);
            Console.WriteLine($"Updated USF file saved at {newFilePath}");
        }
    }
}
