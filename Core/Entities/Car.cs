using Core.Enums;

namespace Core.Entities
{
    public class Car : Vehicle
    {
        public string Engine { get; set; }
        public int NumberOfDoors { get; set; }
        public int NumberOfWheels { get; set; }
        public CarBodyType CarBodyType { get; set; }    
    }
}