using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCarsAndManufacturers2.Services
{
    public interface IDataReaderService
    {
        Task<IEnumerable<Car>> GetCarsEnumerator();
        Task<IEnumerable<Manufacturer>> GetManufacturersEnumerator();
    }
}
