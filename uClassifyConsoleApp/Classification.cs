using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace uClassifyConsoleApp
{
    public class Classification
    {
        [JsonPropertyName("className")]
        public string ClassName { get; set; }

        [JsonPropertyName("p")]
        public double P { get; set; }
    }

    public class UClassifyResult
    {
        [JsonPropertyName("textCoverage")]
        public double TextCoverage { get; set; }

        [JsonPropertyName("classification")]
        public List<Classification> Classification { get; set; }
    }
}