using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehiclesAdsManagement.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int CenaPLN { get; set; }
        public int Rocznik { get; set; }
        public string RodzajPaliwa { get; set; }
        public int PrzebiegKM { get; set; }
        public int PojemnoscCm3 { get; set; }
    }
}
