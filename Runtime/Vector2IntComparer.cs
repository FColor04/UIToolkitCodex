using System.Collections.Generic;
using UnityEngine;

namespace CrossPlatformUtilities.Runtime.SharedFeatures
{
    public class Vector2IntComparer : IComparer<Vector2Int>
    {
        public int Compare(Vector2Int a, Vector2Int b)
        {
            var xComparison = a.x.CompareTo(b.x);
            if (xComparison != 0) return xComparison;
            var yComparison = a.y.CompareTo(b.y);
            return yComparison;
        }
    }
}
