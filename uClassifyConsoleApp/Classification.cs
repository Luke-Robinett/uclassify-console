using Newtonsoft.Json;
using System.Collections.Generic;

namespace uClassifyConsoleApp
{
    public class Classification
    {
        [JsonProperty("className")]
        public string ClassName { get; set; }

        [JsonProperty("p")]
        public double P { get; set; }
    }

    public class UClassifyResult
    {
        [JsonProperty("textCoverage")]
        public double TextCoverage { get; set; }

        [JsonProperty("classification")]
        public List<Classification> Classification { get; set; }
    }
}