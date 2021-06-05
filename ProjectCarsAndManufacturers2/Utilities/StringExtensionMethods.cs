using System;

namespace ProjectCarsAndManufacturers2.Utilities
{
    public static class StringExtensionMethods
    {
        public static Car StringToCar(this string str)
        {
            string[] sarr = str.Split(",");
            return new Car(
                           Id: Guid.NewGuid(),
                           ModelYear: int.Parse(sarr[0]),
                           Division: sarr[1],
                           CarLine: sarr[2],
                           EngineDisplacement: sarr[3],
                           Cylinders: double.Parse(sarr[4]),
                           CityFuelEff: int.Parse(sarr[5]),
                           HighWayFuelEff: int.Parse(sarr[6]),
                           CombinedFuelEff: int.Parse(sarr[7]));
        }

        public static Manufacturer StringToManufacturer(this string str)
        {
            string[] sarr = str.Split(",");
            return new Manufacturer(
                                    Name: sarr[0],
                                    Country: sarr[1],
                                    Year: int.Parse(sarr[2]));    
        }
    }
}
