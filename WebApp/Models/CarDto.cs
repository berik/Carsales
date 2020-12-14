using System;
using Core.Enums;

namespace WebApp.Models
{
    public class CarDto
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public VehicleType VehicleType { get; set; }
        public string Engine { get; set; }
        public int NumberOfDoors { get; set; }
        public int NumberOfWheels { get; set; }
        public CarBodyType CarBodyType { get; set; }    
    }
}