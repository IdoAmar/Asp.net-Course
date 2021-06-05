using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace ProjectCarsAndManufacturers
{
    static class DataReader
    {
        public static IEnumerable<Car> GetAllCars()
        {
            var carStrings = File.ReadAllLines(@"C:\Users\xidoa\Desktop\Fullstack course\Course-2105-Public\Day 05\Project1Solution\Project1Solution\bin\Debug\net5.0\Data\Cars.csv").Skip(1);
            foreach(var item in carStrings)
                yield return item.StringToCar();
        }

        private static Car StringToCar(this string str)
        {
            string[] sarr = str.Split(",");
            return new Car()
            {
                ModelYear = int.Parse(sarr[0]),
                Division = sarr[1],
                CarLine = sarr[2],
                EngineDisplacement = sarr[3],
                Cylinders = double.Parse(sarr[4]),
                CityFuelEff = int.Parse(sarr[5]),
                HighWayFuelEff = int.Parse(sarr[6]),
                CombinedFuelEff = int.Parse(sarr[7])
            };
        }

        public static IEnumerable<Manufacturer> GetAllManufacturers()
        {
            var manufactureresStrings = File.ReadAllLines(@"C:\Users\xidoa\Desktop\Fullstack course\Course-2105-Public\Day 05\Project1Solution\Project1Solution\bin\Debug\net5.0\Data\Manufacturers.csv");
            foreach (var item in manufactureresStrings)
                yield return item.StringToManufacturer();
        }

        private static Manufacturer StringToManufacturer(this string str)
        {
            string[] sarr = str.Split(",");
            return new Manufacturer()
            {
                Name = sarr[0],
                Country = sarr[1],
                Year = int.Parse(sarr[2])
            };
        }
    }
}
