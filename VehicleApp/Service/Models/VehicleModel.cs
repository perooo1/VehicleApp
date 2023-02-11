using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleApp.Service.Models
{
    public class VehicleModel : IDetails
    {
        public string Id { get; set; }
        public string ManufacturerId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}
