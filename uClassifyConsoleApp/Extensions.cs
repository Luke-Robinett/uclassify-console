using System;
using System.Collections.Generic;
using System.Linq;

namespace uClassifyConsoleApp
{
    static class Extensions
    {
        public static int PresentAsMenu(this List<string> options, string prompt)
        {
            var items = Enumerable.Range(0, options.Count)
                .Select(n => (Value: n + 1, Text: options[n]))
                .ToList();

            var valid = false;
            var selection = 0;
            while (!valid)
            {
                Console.WriteLine(prompt);
                foreach (var item in items)
                {
                    Console.WriteLine($"{item.Value}.  {item.Text}");
                }
                Console.Write("Enter number of desired item or hit Enter to cancel: ");
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Exiting menu");
                    return 0;
                }

                if (int.TryParse(input, out selection))
                {
                    if ((selection >= 1) && (selection <= items.Count))
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine(items.Count > 1 ? $"Please choose an option between 1 and {items.Count}." : "Please enter 1.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }

            Console.WriteLine(items[selection - 1].Text);
            return selection;
        }
    }
}