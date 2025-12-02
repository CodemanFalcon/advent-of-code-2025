using AdventOfCode2025.Day1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day1
{
    public class Day1
    {
        public static void Solve(bool V2)
        {
            string filePath = "Day1/Input/Input.txt";

            List<Rotation> rotations = new List<Rotation>();

            try
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    char direction = line[0];
                    int amount = int.Parse(line.Substring(1));
                    Rotation rotation = new Rotation
                    {
                        Direction = direction,
                        Amount = amount
                    };
                    rotations.Add(rotation);
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

            Dial dial = new Dial();

            Console.WriteLine($"The dial starts by pointing at {dial.CurrentPosition}.");

            foreach (Rotation rotation in rotations)
            {
                if (V2)
                    dial.RotateV2(rotation.Direction, rotation.Amount);
                else
                    dial.Rotate(rotation.Direction, rotation.Amount);
                Console.WriteLine($"Dial is Rotated: {rotation.Direction}{rotation.Amount}, Current Position: {dial.CurrentPosition}, Zero Counter: {dial.ZeroCounter}");
            }
            Console.WriteLine($"Answer is {dial.ZeroCounter}");
            Console.ReadLine();
        }
    }
}
