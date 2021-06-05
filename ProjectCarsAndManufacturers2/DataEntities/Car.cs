using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCarsAndManufacturers2
{
    public record Car(Guid Id,
                      int ModelYear,
                      string Division,
                      string CarLine,
                      string EngineDisplacement,
                      double Cylinders,
                      int CityFuelEff,
                      int HighWayFuelEff,
                      int CombinedFuelEff);
}
