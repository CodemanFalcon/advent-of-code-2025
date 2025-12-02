using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day2.Models
{
    public class IdRange
    {
        public long StartId { get; set; }
        public long EndId { get; set; }
        public IdRange(long startId, long endId)
        {
            StartId = startId;
            EndId = endId;
        }

        public List<long> GetInvalidIds()
        {
            List<long> invalidIds = new List<long>();
            for (long i = StartId; i <= EndId; i++)
            {
                if (IsInvalidId(i))
                {
                    invalidIds.Add(i);
                }
            }
            return invalidIds;
        }

        private bool IsInvalidId(long id)
        {
            string idStr = id.ToString();
            string firstHalf = idStr.Substring(0, idStr.Length / 2);
            string secondHalf = idStr.Substring(idStr.Length / 2);
            return firstHalf == secondHalf;
        }

        public List<long> GetInvalidIdsV2()
        {
            List<long> invalidIds = new List<long>();
            for (long i = StartId; i <= EndId; i++)
            {
                if (IsInvalidIdV2(i))
                {
                    invalidIds.Add(i);
                }
            }
            return invalidIds;
        }

        private bool IsInvalidIdV2(long id)
        {
            string idStr = id.ToString();
            for (int chunkSize = 1; chunkSize <= idStr.Length / 2; chunkSize++)
            {
                if (idStr.Length % chunkSize != 0)
                    continue;

                if (IsRepeatingSequence(idStr, chunkSize))
                    return true;
            }

            return false;
        }

        private static bool IsRepeatingSequence(string s, int chunkSize)
        {
            if (chunkSize <= 0 || s.Length % chunkSize != 0)
                return false;

            string first = s.Substring(0, chunkSize);
            for (int i = chunkSize; i < s.Length; i += chunkSize)
            {
                if (!s.Substring(i, chunkSize).Equals(first, StringComparison.Ordinal))
                    return false;
            }
            return true;
        }
    }
}
