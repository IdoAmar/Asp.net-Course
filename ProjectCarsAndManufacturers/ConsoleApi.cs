using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectCarsAndManufacturers
{
    public static class ConsoleApi
    {
        public static void Print(this string str, ConsoleColor consoleColor = ConsoleColor.White)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(str);
        }
        public static (string choice, int choiceNumber) GetUserSelection(this IEnumerable<string> stringsEnum, bool sort = true)
        {
            var sortedEnum = sort ? stringsEnum.OrderBy(s => s) : stringsEnum;
            var selectedEnum = sortedEnum.Select((e, i) => (e, i));
            "Please Select:".Print(ConsoleColor.Yellow);
            foreach (var item in selectedEnum)
            {
                $"{item.i + 1}.{item.e}".Print(ConsoleColor.Magenta);
            }
            while (true)
            {
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int input))
                {
                    if (0 < input && input <= stringsEnum.Count() + 1)
                        return (sortedEnum.ElementAt(input - 1), input);
                    else
                        $"please enter a number between 0 and {sortedEnum.Count()}".Print(ConsoleColor.Red);
                }
                else
                    "Please enter a valid number".Print(ConsoleColor.Red);
            };
        }
    }
}
