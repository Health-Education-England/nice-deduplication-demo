using System.Collections.Generic;

namespace DeduplicationDemo.Models
{
    public class RisFile
    {
        public List<RisFileDoc> Docs { get; set; }
        public bool Valid { get; set; }

        public RisFile()
        {
            Valid = false;
            Docs = new List<RisFileDoc>();
        }
    }
}
