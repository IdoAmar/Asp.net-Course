using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectCarsAndManufacturers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>
                {
                    "List of manufacturers",
                    "List of vehicle by manufacturers",
                    "List of manufacturers and the number of car models they own",
                    "List of Best Cars per Manufacturer from a certain country",
                    "List of unique features",
                };
            while (true)
            {
                var choice = list.GetUserSelection(false);
                switch (choice.choiceNumber)
                {
                    case 1:
                        PrintManufacturersList(Api.GetManufactureresList());
                        break;
                    case 2:
                        Console.WriteLine("\nPlease Select a Manufacturer by number");
                         
                        Api.PrintVehiclesByManufacturers(Api.GetVehiclesByManufacturerByIndex(Api.GetManufactureresList().Select(m => m.Name).GetUserSelection().choice));
                        break;
                    case 3:
                        Api.PrintNumberOfVehiclesPerManufacturer(Api.GetNumberOfVehiclesPerManufacturers());
                        break;
                    case 4:
                        Api.PrintCountries(Api.GetCountries());
                        Api.PrintBestCarsPerManufacturer(Api.BestCarsPerManufacturer(int.Parse(Console.ReadLine())));
                        break;
                    case 5:
                        Api.PrintLowestCombinedEfficiency();
                        Api.PrintAverageCityEfficiency();
                        Api.PrintNumberOfCountries();
                        Api.ManufacturerWithHighestEF();
                        break;
                    default:
                        break;
                }
            }
        }

        public static void PrintManufacturersList(IEnumerable<Manufacturer> mfEnumartor)
        {
            "\nThe Manufacturers are:".Print();
            foreach (var item in mfEnumartor)
            {
                $"{item.Name,-30} | {item.Country, -10}".Print();
            }
            "".Print();
        }
    }
}
