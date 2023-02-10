using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleApp.Service.Models
{
    public interface IDetails
    {
        string Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}
