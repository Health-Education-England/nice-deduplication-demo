using System.Collections.Generic;
using System.Linq;

namespace DeduplicationDemo.Models
{
    public class RisFileDoc
    {
        public RisFileDoc()
        {
            Lines = new List<RisLine>();
        }
        public List<RisLine> Lines { get; private set; }

        public string GetData(string code)
        {
            var line = Lines?.FirstOrDefault(x => x.Code == code);

            if (line == null)
                return "";

            return line.Data;
        }

        public string GetDataMultiple(IEnumerable<string> Codes)
        {
            foreach (var code in Codes)
            {
                var line = Lines.FirstOrDefault(x => x.Code == code);
                if (line == null)
                    continue;
                return line.Data;
            }
            return "";
        }

        public string GetAllDataWithCode(string code)
        {
            var ret = new List<string>();
            foreach (var line in Lines)
            {
                if (line.Code == code)
                    ret.Add(line.Data);
            }
            return string.Join(";", ret);
        }
    }
}

