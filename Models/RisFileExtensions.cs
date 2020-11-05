using System;
using System.Collections.Generic;
using System.Linq;

namespace DeduplicationDemo.Models
{
    public static class RisFileExtensions
    {
        public static string ToPlatformSpecificLineEndings(this string str)
        {
            var normalised = str.Replace("\r\n", "\n")
                .Replace("\r", "\n")
                .Replace("\n", Environment.NewLine);

            return normalised;
        }
    }
}
