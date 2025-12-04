using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day3.Models
{
    public class BatteryBank
    {
        public List<int> Batteries { get; set; }
        public long MaxJoltage { get; set; }
        public BatteryBank(List<int> batteries)
        {
            Batteries = batteries;
        }

        public string ToString()
        {
            return string.Join(",", Batteries);
        }

        public void CalculateMaxJoltage()
        {
            int firstMaxIndex = FindMaxIndexInIndexRange(Batteries, 0, Batteries.Count - 2);
            int secondMaxIndex = FindMaxIndexInIndexRange(Batteries, firstMaxIndex + 1, Batteries.Count - 1);
            MaxJoltage = (Batteries[firstMaxIndex] * 10) + Batteries[secondMaxIndex];
        }

        public int FindMaxIndexInIndexRange(List<int> list, int startIndex, int endIndex)
        {
            if (list == null || list.Count == 0)
            {
                throw new ArgumentException("List cannot be null or empty.");
            }
            if (startIndex < 0 || endIndex >= list.Count || startIndex > endIndex)
            {
                throw new ArgumentOutOfRangeException("Invalid start or end index.");
            }

            int max = list[startIndex]; // Initialize max with the first element in the range
            int maxIndex = startIndex;

            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (list[i] > max)
                {
                    max = list[i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        public void CalculateMaxJoltageV2()
        {
            const int MAX_DIGITS = 12;
            int n = Batteries.Count;

            // Greedy stack algorithm: remove the smallest digits when a larger digit appears
            int toRemove = n - MAX_DIGITS;
            var stack = new List<int>(n);

            foreach (var d in Batteries)
            {
                while (stack.Count > 0 && toRemove > 0 && stack[^1] < d)
                {
                    stack.RemoveAt(stack.Count - 1);
                    toRemove--;
                }
                stack.Add(d);
            }

            // If still need to remove, remove from the end
            if (toRemove > 0)
            {
                stack.RemoveRange(stack.Count - toRemove, toRemove);
            }

            var chosen = stack.Take(MAX_DIGITS);
            MaxJoltage = long.Parse(string.Concat(chosen));
        }
    }
}
