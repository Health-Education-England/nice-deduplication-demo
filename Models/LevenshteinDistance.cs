using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DeduplicationDemo.Models
{
    public class LevenshteinDistance
    {
        public static int ComputePercentage(string s, string t)
        {
            Regex reg = new Regex("[^a-zA-Z0-9]");
            var sClean = reg.Replace(s, string.Empty).ToLower();
            var tClean = reg.Replace(t, string.Empty).ToLower();

            var rawInt = Compute(sClean, tClean);

            if (rawInt > 100)
                return 0;

            int longestLength = (new List<int> { sClean.Length, tClean.Length }).Max();

            float weight = 100f / longestLength;

            float weightedInt = weight * rawInt;

            return (int)(100 - weightedInt);
        }

        public static int Compute(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            // Step 1
            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            // Step 2
            for (int i = 0; i <= n; d[i, 0] = i++)
            {
            }

            for (int j = 0; j <= m; d[0, j] = j++)
            {
            }

            // Step 3
            for (int i = 1; i <= n; i++)
            {
                //Step 4
                for (int j = 1; j <= m; j++)
                {
                    // Step 5
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    // Step 6
                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            // Step 7
            return d[n, m];
        }
    }
}
