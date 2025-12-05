using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2025.Day5.Models
{
    public class Inventory
    {
        public List<FreshIdRange> FreshIdRanges { get; set; } = new List<FreshIdRange>();
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    }

    public class FreshIdRange
    {
        public long StartId { get; set; }
        public long EndId { get; set; }
    }

    // Equality comparer for FreshIdRange so Distinct(...) can remove duplicate ranges
    public class FreshIdRangeComparer : IEqualityComparer<FreshIdRange>
    {
        public bool Equals(FreshIdRange? x, FreshIdRange? y)
        {
            if (ReferenceEquals(x, y))
                return true;
            if (x is null || y is null)
                return false;
            return x.StartId == y.StartId && x.EndId == y.EndId;
        }

        public int GetHashCode(FreshIdRange obj)
        {
            if (obj is null) return 0;
            return HashCode.Combine(obj.StartId, obj.EndId);
        }
    }

    public class Ingredient
    {
        public long Id { get; set; }
        public bool IsFresh { get; set; }
    }
}
