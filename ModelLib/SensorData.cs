using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib
{
    public class SensorData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Temperature { get; set; }
        public int CO2 { get; set; }

        public SensorData(int id, string name, int temperature, int co2)
        {
            Id = id;
            Name = name;
            Temperature = temperature;
            CO2 = co2;
        }
    }
}
