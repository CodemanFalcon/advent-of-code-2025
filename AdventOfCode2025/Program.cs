using AdventOfCode2025.Day1;
using AdventOfCode2025.Day2;
using AdventOfCode2025.Day3;
using AdventOfCode2025.Day4;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Enter Day to Solve or Enter 0 to Exit:");

            string? line = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(line))
            {
                Console.WriteLine("Invalid input. Please enter a valid day number.");
                continue;
            }

            int day;
            if (!int.TryParse(line, out day))
            {
                Console.WriteLine("Invalid input. Please enter a valid day number.");
                continue;
            }

            switch (day)
            {
                case 0:
                    exit = true;
                    break;
                case 1:
                    Console.WriteLine("V1 or V2?");
                    if (Console.ReadLine() == "V2")
                        Day1.Solve(true);
                    else
                        Day1.Solve(false);
                    break;
                case 2:
                    Console.WriteLine("V1 or V2?");
                    if (Console.ReadLine() == "V2")
                        Day2.Solve(true);
                    else
                        Day2.Solve(false);
                    break;
                case 3:
                    Console.WriteLine("V1 or V2?");
                    if (Console.ReadLine() == "V2")
                        Day3.Solve(true);
                    else
                        Day3.Solve(false);
                    break;
                case 4:
                    Console.WriteLine("V1 or V2?");
                    if (Console.ReadLine() == "V2")
                        Day4.SolveV2();
                    else
                        Day4.Solve();
                    break;
                default:
                    Console.WriteLine("Day not implemented");
                    break;
            }
        }

        Console.WriteLine("Goodbye");
        Console.ReadLine();
    }
}