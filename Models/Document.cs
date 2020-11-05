using System.Collections.Generic;
using System.Linq;

namespace DeduplicationDemo.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string PubMedID { get; set; } = "";
        public string Title { get; set; } = "";
        public string Journal { get; set; } = "";
        public string DOI { get; set; } = "";
        public string PublicationYear { get; set; } = "";
        public string Volume { get; set; } = "";
        public string Issn { get; set; } = "";
        public string StartPage { get; set; } = "";
        public string EndPage { get; set; } = "";
        public string Issue { get; set; } = "";
        public string Authors { get; set; } = "";
        public string Citation { get; set; } = "";
        public string Abstract { get; set; } = "";
        public List<(string, double)> DeduplicationCandidates { get; set; } = new List<(string,double)>();
        


        public Document(RisFileDoc doc, int id)
        {
            Title = doc.GetDataMultiple(RisCode.TitleCodes);
            Journal = doc.GetDataMultiple(RisCode.JournalCodes);
            DOI = doc.GetData(RisCode.DOI);
            PublicationYear =
                GetPublicationYear(new List<string>() {
                    doc.GetData(RisCode.PublicationYear),
                    doc.GetData(RisCode.PrimaryYear) });
            Volume = doc.GetData(RisCode.Volume);
            Issn = doc.GetData(RisCode.Issn);
            StartPage = doc.GetData(RisCode.StartPage);
            EndPage = doc.GetData(RisCode.EndPage);
            Issue = doc.GetData(RisCode.Issue);
            Authors = GetAuthors(doc);
            Citation = GetCitation();
            Id = id;
            Abstract = doc.GetData(RisCode.Abstract);
        }

        public static string GetPublicationYear(IEnumerable<string> dates)
        {
            return (dates ?? new List<string>())
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .FirstOrDefault() ?? "";
        }

        private string GetAuthors(RisFileDoc doc)
        {
            string authors = doc.GetAllDataWithCode(RisCode.AuthorAU);

            if (string.IsNullOrEmpty(authors))
                authors = doc.GetAllDataWithCode(RisCode.Author);

            return authors.Replace(";", "; ");
        }

        public string GetCitation()
        {
            var issueInformation = (string.IsNullOrEmpty(Volume) ? "" : $"vol. {Volume}")
                    + (string.IsNullOrEmpty(Issue) ? "" : $" (no. {Issue})");

            var info = new List<string>
                {
                    Journal,
                    PublicationYear,
                    issueInformation,
                    $"{StartPage}-{EndPage}"
                };

            return string.Join("; ", info.Where(x => !string.IsNullOrEmpty(x)).ToArray());
        }
    }
}
