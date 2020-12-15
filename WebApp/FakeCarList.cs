using System.Collections.Generic;
using Core.Enums;

namespace WebApp
{
    public static class FakeCarList
    {
        public static List<CarMake> GetFakeCarList()
        {
            return new List<CarMake>()
            {
                new CarMake()
                {
                    Name = "VW",
                    Models = new List<CarModel>()
                    {
                        new CarModel()
                        {
                            Name = "Passat",
                            Engine = "1111",
                            VehicleType = VehicleType.Car,
                            NumberOfWheels = 4
                        },
                        new CarModel()
                        {
                            Name = "Jetta",
                            Engine = "2222",
                            VehicleType = VehicleType.Car,
                            NumberOfWheels = 4
                        },
                        new CarModel()
                        {
                            Name = "Golf",
                            Engine = "3333",
                            VehicleType = VehicleType.Car,
                            NumberOfWheels = 4
                        },
                    }
                },
                new CarMake()
                {
                    Name = "BMW",
                    Models = new List<CarModel>()
                    {
                        new CarModel()
                        {
                            Name = "3 Series",
                            Engine = "4444",
                            VehicleType = VehicleType.Car,
                            NumberOfWheels = 4
                        },
                        new CarModel()
                        {
                            Name = "5 Series",
                            Engine = "5555",
                            VehicleType = VehicleType.Car,
                            NumberOfWheels = 4
                        },
                        new CarModel()
                        {
                            Name = "7 Series",
                            Engine = "6666",
                            VehicleType = VehicleType.Car,
                            NumberOfWheels = 4
                        },
                    }
                },
                new CarMake()
                {
                    Name = "Mercedes-Benz",
                    Models = new List<CarModel>()
                    {
                        new CarModel()
                        {
                            Name = "GLE",
                            Engine = "7777",
                            VehicleType = VehicleType.Car,
                            NumberOfWheels = 4
                        },
                        new CarModel()
                        {
                            Name = "E-Class",
                            Engine = "8888",
                            VehicleType = VehicleType.Car,
                            NumberOfWheels = 4
                        },
                        new CarModel()
                        {
                            Name = "S-Class",
                            Engine = "9999",
                            VehicleType = VehicleType.Car,
                            NumberOfWheels = 4
                        },
                    }
                }
            };
        }
    }

    public class CarMake
    {
        public string Name { get; set; }
        public List<CarModel> Models { get; set; }
    }

    public class CarModel
    {
        public string Name { get; set; }
        public VehicleType VehicleType { get; set; }
        public int NumberOfWheels { get; set; }
        public string Engine { get; set; }
    }
}