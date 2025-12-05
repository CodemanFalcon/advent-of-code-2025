using AdventOfCode2025.Day5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day5
{
    public class Day5
    {
        public static void Solve(bool v2)
        {
            string filePath = "Day5/Input/input.txt";

            var inventory = new Inventory();

            try
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    if(string.IsNullOrWhiteSpace(line))
                        continue;
                    else if (line.Contains("-"))
                    {
                        var rangeParts = line.Split("-", StringSplitOptions.TrimEntries);
                        var freshIdRange = new FreshIdRange
                        {
                            StartId = long.Parse(rangeParts[0]),
                            EndId = long.Parse(rangeParts[1])
                        };
                        inventory.FreshIdRanges.Add(freshIdRange);
                    }
                    else
                    {
                        var ingredient = new Ingredient
                        {
                            Id = long.Parse(line),
                            IsFresh = inventory.FreshIdRanges.Any(range => long.Parse(line) >= range.StartId && long.Parse(line) <= range.EndId)
                        };
                        inventory.Ingredients.Add(ingredient);
                    }
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

            int freshCount = inventory.Ingredients.Count(ing => ing.IsFresh);

            Console.WriteLine($"Number of fresh ingredients: {freshCount}");

            //Part 2 Get number of distinct FreshIds contained in any range
            Console.WriteLine($"Calculating distinct fresh IDs in all ranges... {inventory.FreshIdRanges.Count()} total ranges");

            inventory.FreshIdRanges = inventory.FreshIdRanges.OrderBy(r => r.StartId).ToList();
            foreach (var range in inventory.FreshIdRanges)
            {
                foreach (var otherRange in inventory.FreshIdRanges)
                {
                    if (range == otherRange)
                        continue;
                    // Check for overlap
                    if (range.StartId <= otherRange.EndId && otherRange.StartId <= range.EndId)
                    {
                        // Merge ranges
                        range.StartId = Math.Min(range.StartId, otherRange.StartId);
                        range.EndId = Math.Max(range.EndId, otherRange.EndId);
                        otherRange.StartId = range.StartId;
                        otherRange.EndId = range.EndId;
                    }
                }
            }
            inventory.FreshIdRanges = inventory.FreshIdRanges.Distinct(new FreshIdRangeComparer()).ToList();

            Console.WriteLine($"Paired overlapping ranges together... {inventory.FreshIdRanges.Count()} total ranges");

            long distinctFreshIds = 0;
            foreach (var range in inventory.FreshIdRanges)
            {
                distinctFreshIds += (range.EndId - range.StartId + 1);
            }

            Console.WriteLine($"Total distinct fresh IDs in all ranges: {distinctFreshIds}");

            Console.WriteLine("Day 5 solution executed.");
        }
    }
}
