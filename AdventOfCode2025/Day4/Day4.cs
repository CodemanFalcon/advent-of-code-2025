using AdventOfCode2025.Day3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day4
{
    public class Day4
    {
        public static void Solve()
        {
            string filePath = "Day4/Input/input.txt";

            var grid = new List<List<char>>();

            try
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    var result = new List<char>();
                    foreach (char ch in line)
                    {
                        result.Add(ch);
                    }
                    grid.Add(result);
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

            var newGrid = new List<List<char>>();
            foreach (var row in grid)
            {
                var newRow = new List<char>();
                foreach (var ch in row)
                {
                    newRow.Add(ch);
                }
                newGrid.Add(newRow);
            }

            for (int i = 0; i < grid.Count; i++)
            {
                for (int j = 0; j < grid[i].Count; j++)
                {
                    int rollsAround = 0;
                    if (grid[i][j] == '@')
                    {
                        if (j > 0 && grid[i][j - 1] == '@') rollsAround++;
                        if (j < grid[i].Count - 1 && grid[i][j + 1] == '@') rollsAround++;
                        if (i > 0 && grid[i - 1][j] == '@') rollsAround++;
                        if (i < grid.Count - 1 && grid[i + 1][j] == '@') rollsAround++;
                        if (i > 0 && j > 0 && grid[i - 1][j - 1] == '@') rollsAround++;
                        if (i > 0 && j < grid[i].Count - 1 && grid[i - 1][j + 1] == '@') rollsAround++;
                        if (i < grid.Count - 1 && j > 0 && grid[i + 1][j - 1] == '@') rollsAround++;
                        if (i < grid.Count - 1 && j < grid[i].Count - 1 && grid[i + 1][j + 1] == '@') rollsAround++;

                        if (rollsAround < 4)
                        {
                            newGrid[i][j] = 'X';
                        }
                    }
                }
            }

            foreach (var row in newGrid)
            {
                Console.WriteLine(string.Join("", row));
            }

            int totalAvailable = 0;
            foreach (var row in newGrid)
            {
                foreach (var ch in row)
                {
                    if (ch == 'X')
                    {
                        totalAvailable++;
                    }
                }
            }
            Console.WriteLine($"{totalAvailable} Rolls Available!");
            Console.WriteLine("Day 4 solved!");

        }

        public static void SolveV2()
        {
            string filePath = "Day4/Input/input.txt";

            var prevGrid = new List<List<char>>();

            try
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    var result = new List<char>();
                    foreach (char ch in line)
                    {
                        result.Add(ch);
                    }
                    prevGrid.Add(result);
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

            bool done = false;
            int loopCounter = 1;
            int totalAvailable = 0;

            while (!done)
            {
                var newGrid = new List<List<char>>();
                foreach (var row in prevGrid)
                {
                    var newRow = new List<char>();
                    foreach (var ch in row)
                    {
                        newRow.Add(ch);
                    }
                    newGrid.Add(newRow);
                }

                for (int i = 0; i < prevGrid.Count; i++)
                {
                    for (int j = 0; j < prevGrid[i].Count; j++)
                    {
                        int rollsAround = 0;
                        if (prevGrid[i][j] == '@')
                        {
                            if (j > 0 && prevGrid[i][j - 1] == '@') rollsAround++;
                            if (j < prevGrid[i].Count - 1 && prevGrid[i][j + 1] == '@') rollsAround++;
                            if (i > 0 && prevGrid[i - 1][j] == '@') rollsAround++;
                            if (i < prevGrid.Count - 1 && prevGrid[i + 1][j] == '@') rollsAround++;
                            if (i > 0 && j > 0 && prevGrid[i - 1][j - 1] == '@') rollsAround++;
                            if (i > 0 && j < prevGrid[i].Count - 1 && prevGrid[i - 1][j + 1] == '@') rollsAround++;
                            if (i < prevGrid.Count - 1 && j > 0 && prevGrid[i + 1][j - 1] == '@') rollsAround++;
                            if (i < prevGrid.Count - 1 && j < prevGrid[i].Count - 1 && prevGrid[i + 1][j + 1] == '@') rollsAround++;

                            if (rollsAround < 4)
                            {
                                newGrid[i][j] = 'X';
                            }
                        }
                    }
                }

                Console.WriteLine($"Iteration: {loopCounter}");
                foreach (var row in newGrid)
                {
                    Console.WriteLine(string.Join("", row));
                }

                int currentGridAvailable = 0;
                foreach (var row in newGrid)
                {
                    foreach (var ch in row)
                    {
                        if (ch == 'X')
                        {
                            currentGridAvailable++;
                        }
                    }
                }
                if (currentGridAvailable == 0)
                {
                    done = true;
                }
                else
                {
                    totalAvailable += currentGridAvailable;
                    prevGrid = new List<List<char>>();
                    foreach (var row in newGrid)
                    {
                        var newRow = new List<char>();
                        foreach (var ch in row)
                        {
                            if(ch == 'X')
                                newRow.Add('.');
                            else
                                newRow.Add(ch);
                        }
                        prevGrid.Add(newRow);
                    }
                }
                loopCounter++;
            }
            Console.WriteLine($"{totalAvailable} Rolls Available!");
            Console.WriteLine("Day 4 V2 solved!");
        }
    }
}
