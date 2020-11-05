namespace DeduplicationDemo.Models
{
    public static class RisCode
    {
        public const string Type = "TY";
        public const string TitlePrimary = "T1";
        public const string Title = "TI";
        public const string Citation = "JF";
        public const string Journal = "JO";
        public const string PublicationYear = "PY";
        public const string PrimaryYear = "Y1";
        public const string DOI = "DO";
        public const string End = "ER";
        public const string Volume = "VL";
        public const string Issn = "SN";
        public const string StartPage = "SP";
        public const string EndPage = "EP";
        public const string Issue = "IS";
        public const string Author = "A1";
        public const string AuthorAU = "AU";
        public const string Abstract = "AB";


        public static readonly string[] TitleCodes = new[]
        {
            TitlePrimary,
            Title
        };

        public static readonly string[] JournalCodes = new[]
        {
            Citation,
            Journal
        };

    }
}
