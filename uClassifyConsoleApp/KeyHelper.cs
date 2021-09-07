using System;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace uClassifyConsoleApp
{
    public static class KeyHelper
    {
        public static async Task<string> RetrieveFromFile()
        {
            var filename = Path.Combine(Directory.GetCurrentDirectory(), "key.json");
            var json = await File.ReadAllTextAsync(filename);
            var result = JsonSerializer.Deserialize<Dictionary<string, string>>(json, new JsonSerializerOptions { IncludeFields = true });

            return result["Key"];
        }
    }
}