using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace uClassifyConsoleApp
{
    public class UClassifyAPI
    {
        private readonly string _key;

        public UClassifyAPI(string key)
        {
            _key = key;
        }

        public async Task<List<string>> GetPrimaryTopicsAsync(string inputText)
        {
            return await GetAsync(inputText, "uclassify/topics/classify");
        }

        private async Task<List<string>> GetAsync(string inputText, string route)
        {
            using (var client = new HttpClient
            {
                BaseAddress = new Uri("https://api.uclassify.com/v1/")
            })
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Token", _key);
                var requestBody = "{\"texts\": [\"" + inputText + "\"]}";
                var response = await client.PostAsync(route, new StringContent(requestBody));
                var classificationResults = await response.Content.ReadFromJsonAsync<List<UClassifyResult>>();
                var classificationResult = classificationResults.FirstOrDefault();

                var topMatches = classificationResult.Classification
                    .Where(c => c.P >= .01)
                    .OrderByDescending(c => c.P)
                    .Take(3)
                    .Select(c => c.ClassName);

                return topMatches.ToList();
            }
        }

        public async Task<List<string>> GetSecondaryTopicsAsync(string primaryTopic, string inputText)
        {
            if (string.IsNullOrWhiteSpace(primaryTopic))
            {
                throw new ArgumentException("Must provide primary topic.");
            }
            if (string.IsNullOrWhiteSpace(inputText))
            {
                throw new ArgumentException("Must provide input text string.");
            }

            var route = primaryTopic switch
            {
                "Arts" => "uclassify/art-topics/classify",
                "Business" => "uclassify/business-topics/classify",
                "Computers" => "uclassify/computer-topics/classify",
                "Games" => "uclassify/game-topics/classify",
                "Health" => "uclassify/health-topics/classify",
                "Home" => "uclassify/home-topics/classify",
                "Recreation" => "uclassify/recreation-topics/classify",
                "Science" => "uclassify/science-topics/classify",
                "Society" => "uclassify/society-topics/classify",
                "Sports" => "uclassify/sport-topics/classify",
                _ => throw new ArgumentException("That primary category doesn't exist.")
            };

            return await GetAsync(inputText, route);
        }
    }
}
