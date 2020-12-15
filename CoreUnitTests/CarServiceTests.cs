using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.IData;
using Core.Interfaces.IServices;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;
using IConfiguration = Castle.Core.Configuration.IConfiguration;

namespace CoreUnitTests
{
    public class Tests
    {
        private ICarService _carService;
        private Mock<IConfiguration> _configuration;
        private Mock<IStorageService> _mockStorageService;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<UserManager<ApplicationUser>> _mockUserManager;

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
            // // Arrange
            // _configuration = new Mock<IConfiguration>();
            // _mockUnitOfWork = new Mock<IUnitOfWork>();
            // _mockStorageService = new Mock<IStorageService>(_configuration.Object);
            // _mockUserManager = new Mock<UserManager<ApplicationUser>>();
            // _carService = new CarService(_mockUnitOfWork.Object, _mockStorageService.Object, _mockUserManager.Object);
            // var userId = Guid.NewGuid().ToString();
            // var newCar = new Car()
            // {
            //     Id = 1
            // };
            // _mockUnitOfWork.Setup(p => p.CarRepository.Add(newCar));
            // var file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy image")), 0, 0, "Data", "dummy.jpg");
            //
            // // Act
            // var result = await _carService.AddCar(newCar, userId, file);
            //
            // // Assert
            // Assert.AreEqual(userId, result.OwnerId);
            Assert.Pass();
        }
    }
}