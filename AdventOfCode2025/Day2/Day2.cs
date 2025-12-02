using AdventOfCode2025.Day2.Models;

namespace AdventOfCode2025.Day2
{
    public class Day2
    {
        public static void Solve(bool v2)
        {
            string filePath = "Day2/Input/input.txt";

            List<string> ranges = new List<string>();

            try
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    line.Split(',').ToList().ForEach(x => ranges.Add(x));
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

            List<IdRange> idRanges = new List<IdRange>();

            foreach (string range in ranges)
            {
                Console.WriteLine(range);
                long startId = long.Parse(range.Split('-')[0]);
                long endId = long.Parse(range.Split('-')[1]);
                idRanges.Add(new IdRange(startId, endId));
            }

            List<long> allInvalidIds = new List<long>();

            foreach (IdRange idRange in idRanges)
            {
                Console.WriteLine($"StartId: {idRange.StartId}, EndId: {idRange.EndId}");
                List<long> invalidIds;
                if (v2)
                {
                    invalidIds = idRange.GetInvalidIdsV2();
                }
                else
                {
                    invalidIds = idRange.GetInvalidIds();
                }
                foreach (long invalidId in invalidIds)
                {
                    Console.WriteLine($"Invalid Id: {invalidId}");
                }
                allInvalidIds.AddRange(invalidIds);
            }

            long sum = allInvalidIds.Sum();
            Console.WriteLine($"Sum of all invalid Ids: {sum}");
            Console.ReadLine();
        }
    }
}
