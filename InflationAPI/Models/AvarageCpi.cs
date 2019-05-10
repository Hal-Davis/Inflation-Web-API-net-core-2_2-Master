using System;
using System.Collections.Generic;

namespace InflationAPI.Models
{
    public partial class AvarageCpi
    {
        public int Year { get; set; }
        public double? AvgCpi { get; set; }
    }
}
