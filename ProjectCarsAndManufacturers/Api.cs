using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace ProjectCarsAndManufacturers
{
    public static class Api
    {
        public static IEnumerable<Manufacturer> GetManufactureresList()
        {
            return DataReader.GetAllManufacturers()
                             .OrderBy(m => m.Name);
        }

       

        public static IEnumerable<Car> GetVehiclesByManufacturerByIndex(string choice)
        {
            return DataReader.GetAllCars()
                             .Where(c => c.Division == choice)
                             .OrderBy(c => c.CarLine)
                             .ThenBy(c => c.Cylinders);
        }

        public static void PrintVehiclesByManufacturers(IEnumerable<Car> veEnumerator)
        {
            Console.WriteLine("\nVehicles by " + veEnumerator.First().Division + ":\n");
            foreach (var item in veEnumerator)
                Console.WriteLine(item.ModelYear.ToString() + ", " + item.Division + ", " +
                                  item.CarLine + ", " + item.EngineDisplacement + ", " +
                                  item.Cylinders.ToString() + ", " + item.CityFuelEff.ToString() + ", " +
                                  item.HighWayFuelEff.ToString() + ", " + item.CombinedFuelEff.ToString());
            Console.WriteLine();
        }

        public static IEnumerable<(string, int)> GetNumberOfVehiclesPerManufacturers()
        {
            return DataReader.GetAllCars().GroupBy(c => c.Division)
                                          .OrderBy(g => g.Key)
                                          .Select(g => (Name: g.Key, Number: g.Count()));
        }

        public static void PrintNumberOfVehiclesPerManufacturer(IEnumerable<(string Name, int Number)> mfEnumerator)
        {
            Console.WriteLine("\nList of manufacturers and their models amount :\n");
            foreach (var item in mfEnumerator)
                Console.WriteLine(item.Name + " : " + item.Number);
            Console.WriteLine();
        }

        public static IEnumerable<string> GetCountries()
        {
            return DataReader.GetAllManufacturers().GroupBy(m => m.Country).OrderBy(g => g.Key).Select(g => g.Key);
        }

        public static void PrintCountries(IEnumerable<string> mfEnumerator)
        {
            int counter = 1;
            Console.WriteLine("\nPlease Choose a manufacturer country:\n");
            foreach (var item in mfEnumerator)
            {
                Console.WriteLine(counter + "." + item);
                counter++;
            }
            Console.WriteLine();
        }


        public static IEnumerable<(Manufacturer, IEnumerable<Car>)> BestCarsPerManufacturer(int index)
        {
            string country = GetCountries().ElementAtOrDefault(index - 1);
            var manufacturers = DataReader.GetAllManufacturers().Where(m => m.Country == country);
            return manufacturers.Select(m => (m, DataReader.GetAllCars().Where(c => c.Division == m.Name).OrderByDescending(c => c.CombinedFuelEff).Take(3)));
        }

        public static void PrintBestCarsPerManufacturer(IEnumerable<(Manufacturer mf, IEnumerable<Car> topCars)> mfAndCarsEnum)
        {
            Console.WriteLine("The best cars per manufacturer\n");
            foreach (var item in mfAndCarsEnum)
            {
                Console.WriteLine(item.mf.Name + "\n");
                foreach (var cars in item.topCars)
                    Console.WriteLine(cars.CarLine + ", " + cars.ModelYear + ", " + cars.CombinedFuelEff);
                Console.WriteLine();
            }
        }

        public static Car LowestCombinedEfficiency()
        {
            return DataReader.GetAllCars()
                             .Aggregate((comparer, current) => comparer.CombinedFuelEff > current.CombinedFuelEff ? current : comparer);
        }

        public static void PrintLowestCombinedEfficiency()
        {
            Console.WriteLine($"\nThe car with the lowest combined efficiency is: {LowestCombinedEfficiency().CarLine}\n");
        }

        public static void PrintAverageCityEfficiency()
        {
            Console.WriteLine("\nThe Average city fuel efficiency is : " + DataReader.GetAllCars().Average(c => c.CityFuelEff) + "\n");
        }

        public static void PrintNumberOfCountries()
        {
            Console.WriteLine("\nThe number of countries of manufacturers is : " + DataReader.GetAllManufacturers().GroupBy(m => m.Country).Count() + "\n");
        }

        public static void ManufacturerWithHighestEF()
        {
            var maxEff = DataReader.GetAllCars()
                                   .GroupBy(c => c.Division)
                                   .Select(g => (Name: g.Key, Average: g.Average(c => c.CombinedFuelEff)))
                                   .Aggregate((max, current) => current.Average > max.Average ? current : max);
            Console.WriteLine("Manufacturer with the highest efficiency is : " + maxEff.Name + " with an average of : " + maxEff.Average + "\n");
        }
    }
}
