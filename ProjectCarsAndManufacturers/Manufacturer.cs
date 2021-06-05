using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCarsAndManufacturers
{
    public class Manufacturer
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public int Year { get; set; }

        public override string ToString() =>  Name + ", " + Country + ", " + Year.ToString();
    }
}
