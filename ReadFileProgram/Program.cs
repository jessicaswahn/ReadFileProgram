
using System.Text.RegularExpressions;

namespace ReadFileProgram
{

    public class Program
    {

        static void Main(string[] args)
        {
            Program program = new Program();

            if (program.ValidArgument(args))
            {
                program.ReadFile(args);
            }
        }

        public bool ValidArgument(string[] args)
        {
            if (args.Count() <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The program need at least one argument to run");
                Console.ResetColor();
                return false;
            }
            if (!File.Exists(args[0]))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File not found. Something wrong with the path or the file doesnt exist");
                Console.ResetColor();
                return false;
            }

            return true;
        }

        public void ReadFile(string[] args)
        {
            foreach (var arg in args)
            {
                var fileName = Path.GetFileName(arg);
                string nameOfFile = fileName.Substring(0, fileName.IndexOf('.'));

                int counter = 0;

                using (StreamReader file = new StreamReader(arg))
                {
                    while (!file.EndOfStream)
                    {
                        var line = file.ReadLine();

                        if (string.IsNullOrEmpty(line))
                        {
                            continue;
                        }

                        if (line.Contains(nameOfFile))
                        {
                            counter += Regex.Matches(line, nameOfFile).Count;
                        }
                    }
                }

                Console.WriteLine($"Found {counter} '{nameOfFile}' in the file named {fileName}");
            }
        }
    }
}

