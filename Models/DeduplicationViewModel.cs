using System.Collections.Generic;
using System.Linq;

namespace DeduplicationDemo.Models
{
    public class DeduplicationViewModel
    {
        public List<Document> Members { get; set; } = new List<Document>();

        public DeduplicationViewModel(List<Document> docs, Dictionary<string, List<KeyValuePair<string, double>>> deduplicationResults)
        {
            foreach(var item in docs)
            {
                if (deduplicationResults.ContainsKey(item.Id.ToString()))
                    item.DeduplicationCandidates = deduplicationResults[item.Id.ToString()].Select(x=>(x.Key, x.Value)).ToList();

                Members.Add(item);
            }

        }
    }
}
