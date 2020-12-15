using System;
using Core.Enums;
using Microsoft.AspNetCore.Http;

namespace WebApp.Models
{
    public class CarDto
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Price { get; set; }
        public VehicleType VehicleType { get; set; }
        public string Engine { get; set; }
        public int NumberOfDoors { get; set; }
        public int NumberOfWheels { get; set; }
        public string Image { get; set; }
        public CarBodyType CarBodyType { get; set; }    
    }

    public class NewCarDto
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Engine { get; set; }
        public string Price { get; set; }
        public int NumberOfDoors { get; set; }
        public int NumberOfWheels { get; set; }
        public IFormFile Image { get; set; }
        public CarBodyType CarBodyType { get; set; }   
    }
}