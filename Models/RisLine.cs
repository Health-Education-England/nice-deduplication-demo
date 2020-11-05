namespace DeduplicationDemo.Models
{
    public class RisLine
    {
        public RisLine(LineType lineType)
        {
            LineType = lineType;
        }
        public LineType LineType { get; set; }
        public string Code { get; set; }
        public string Data { get; set; }
        public RisLine[] ContinuationLines { get; internal set; }
    }
}
