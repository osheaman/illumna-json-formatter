using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormatJson.Service.Data.Dto
{
    public class FormattedData
    {
        public string PathValue { get; set; }
        public UrlSize UrlSize { get; set; }
    }
    public class UrlSize
    {
        public string Url { get; set; }
        public int Size { get; set; }
    }
}
