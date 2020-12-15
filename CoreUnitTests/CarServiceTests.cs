using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.IData;
using Core.Interfaces.IServices;
using Core.Services;
using Moq;
using NUnit.Framework;

namespace CoreUnitTests
{
    public class Tests
    {
        private ICarService _carService;
        private Mock<IUnitOfWork> _mockUnitOfWork;


        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        
        [Test]
        public async Task CheckIfUserIdIsAttachedTo()
        {
            // Arrange

            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _carService = new CarService(_mockUnitOfWork.Object);
            var userId = Guid.NewGuid().ToString();
            var newCar = new Car()
            {
                Id = 1
            };
            
            _mockUnitOfWork.Setup(p => p.CarRepository.Add(newCar));
            
            // Act
            await _carService.AddCar(newCar, userId);
            
            // Assert
            Assert.AreEqual(userId, newCar.OwnerId);
        }
    }
}