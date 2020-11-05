using DeduplicationDemo.Models;
using System.Collections.Generic;

namespace DeduplicationDemo.Services
{
    public static class DeduplicationService
    {
        public static Dictionary<string, List<KeyValuePair<string, double>>> DeduplicateRecords(List<Document> documents)
        {
            Dictionary<string, List<KeyValuePair<string, double>>> pairs = new Dictionary<string, List<KeyValuePair<string, double>>>();

            if (documents != null && documents.Count > 1)
            {
                for (int documentPos = 0; documentPos < documents.Count; documentPos++)
                {
                    var document = documents[documentPos];
                    if (document != null)
                    {
                        for (int subDocumentPos = documentPos + 1; subDocumentPos < documents.Count; subDocumentPos++)
                        {
                            var subDocument = documents[subDocumentPos];

                            if (subDocument != null)
                            {
                                string docId = document.Id.ToString();
                                string subDocId = subDocument.Id.ToString();

                                double rank = 0;

                                if (docId != subDocId)
                                {
                                    if (!string.IsNullOrEmpty(document.PubMedID) && document.PubMedID.Length == 8 && !string.IsNullOrEmpty(subDocument.PubMedID) && document.PubMedID == subDocument.PubMedID)
                                    {
                                        rank = 100;
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(document.Title) && !string.IsNullOrEmpty(subDocument.Title))
                                            rank = LevenshteinDistance.ComputePercentage(document.Title.ToLower(), subDocument.Title.ToLower());
                                    }
                                }

                                if (rank > 90)
                                {
                                    if (!pairs.ContainsKey(docId))
                                    {
                                        pairs.Add(docId, new List<KeyValuePair<string, double>>());
                                    }
                                    pairs[docId].Add(new KeyValuePair<string, double>(subDocId, rank));

                                }
                            }
                        }
                    }
                }
            }
            return pairs;
        }
    }
}
