using AdventOfCode2025.Day3.Models;

namespace AdventOfCode2025.Day3
{
    public class Day3
    {
        public static void Solve(bool v2)
        {
            string filePath = "Day3/Input/input.txt";

            List<BatteryBank> lines = new List<BatteryBank>();

            try
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    var result = new List<int>();
                    foreach (char ch in line)
                    {
                        result.Add(int.Parse(ch.ToString()));
                    }
                    lines.Add(new BatteryBank(result));
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Error: File not found at '{filePath}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            foreach (var bank in lines)
            {
                if (v2)
                {
                    bank.CalculateMaxJoltageV2();
                }
                else
                {
                    bank.CalculateMaxJoltage();
                }
                Console.WriteLine(bank.ToString() + ", Max Joltage: " + bank.MaxJoltage);
            }

            long sum = 0;
            foreach (var bank in lines)
            {
                sum += bank.MaxJoltage;
            }

            Console.WriteLine($"The Max Joltage is: {sum}");
            Console.ReadLine();
        }
    }
}
