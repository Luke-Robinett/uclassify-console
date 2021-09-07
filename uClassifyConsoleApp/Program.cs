using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace uClassifyConsoleApp
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                var key = await KeyHelper.RetrieveFromFile();
                var api = new UClassifyAPI(key);

                WriteIntro();

                var quit = false;
                while (!quit)
                {
                    Console.Write("Enter text or press Enter to quit: ");
                    var inputText = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(inputText))
                    {
                        var primaryTopics = await api.GetPrimaryTopicsAsync(inputText);
                        var selection = primaryTopics.PresentAsMenu("Choose topic that broadly relates to your query:");

                        if (selection > 0)
                        {
                            var secondaryTopics = await api.GetSecondaryTopicsAsync(primaryTopics[selection - 1], inputText);
                            var nextSelection = secondaryTopics.PresentAsMenu("Next, choose the topic that more specifically matches your query:");

                            if (nextSelection > 0)
                            {
                                Console.WriteLine("Great choice!");
                            }
                        }
                    }
                    else
                    {
                        quit = true;
                    }
                }

                Console.WriteLine("Goodbye!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void WriteIntro()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the uClassify API Console App");
            Console.WriteLine("----------------------------");
            Console.WriteLine();
        }
    }
}