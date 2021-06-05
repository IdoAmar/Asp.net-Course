using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using ProjectCarsAndManufacturers2.Utilities;

namespace ProjectCarsAndManufacturers2.Services
{
    public class DataReaderService : IDataReaderService
    {
        private const string _basePath = "Data";
        private const string _carsFile = "Cars.csv";
        private const string _manufacturersFile = "Manufacturers.csv";

        public Task<IEnumerable<Car>> GetCarsEnumerator()
        {
            var carsEnumerable = File.ReadAllLines($"{_basePath}/{_carsFile}")
                                     .Skip(1)
                                     .Where( s => !String.IsNullOrEmpty(s))
                                     .Select(s => s.Trim().StringToCar());
            return Task.FromResult(carsEnumerable);
        }

        public Task<IEnumerable<Manufacturer>> GetManufacturersEnumerator()
        {

            var manufacturersEnumerable = File.ReadAllLines($"{_basePath}/{_manufacturersFile}")
                                              .Where(s => !String.IsNullOrEmpty(s))
                                              .Select(s => s.Trim().StringToManufacturer());
            return Task.FromResult(manufacturersEnumerable);
        }
    }
}
