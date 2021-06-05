using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCarsAndManufacturers
{
    public class Car
    {
        public int ModelYear { get; set; }
        public string Division { get; set; }
        public string CarLine { get; set; }
        public string EngineDisplacement { get; set; }
        public double Cylinders { get; set; }
        public int CityFuelEff { get; set; }
        public int HighWayFuelEff { get; set; }
        public int CombinedFuelEff { get; set; }
        public override string ToString()
        {
            return ModelYear.ToString() + ", " + Division + ", " + 
                   CarLine + ", " + EngineDisplacement + ", " + 
                   Cylinders.ToString() + ", " + CityFuelEff.ToString() + ", " + 
                   HighWayFuelEff.ToString() + ", " + CombinedFuelEff.ToString();
        }
    }
}
