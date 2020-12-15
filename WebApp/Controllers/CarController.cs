using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.IData;
using Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
    public class CarController : ApiBaseController
    {
        private readonly ILogger<CarController> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;
        private readonly ICarService _carService;
        private readonly IStorageService _storageService;

        public CarController(ILogger<CarController> logger, IMapper mapper, IUnitOfWork unitOfWork,
            ICurrentUserService currentUserService, ICarService carService, IStorageService storageService)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
            _carService = carService;
            _storageService = storageService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation($"Retrieve all cars by userID: {_currentUserService.UserId}");
            var cars = await _unitOfWork.CarRepository.GetAllAsync(_currentUserService.UserId);
            var result = _mapper.Map<List<CarDto>>(cars);
            return Ok(result);
        }

        [HttpGet("{carId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int carId)
        {
            _logger.LogInformation($"Retrieve car for ID: {carId} by userID: {_currentUserService.UserId}");
            var car = await _unitOfWork.CarRepository.GetByIdAsync(carId);
            if (car != null) return Ok(_mapper.Map<CarDto>(car));

            _logger.LogError($"Specified car for ID: {carId} is not found.");
            return NotFound();
        }

        [HttpGet("[action]")]
        public IActionResult GetCarModels()
        {
            _logger.LogInformation($"Retrieve all car models by userID: {_currentUserService.UserId}");
            return Ok(FakeCarList.GetFakeCarList());
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddCar([FromForm] NewCarDto dto)
        {
            try
            {
                _logger.LogInformation($"Create new car ad by userID: {_currentUserService.UserId}");
                var newCar = _mapper.Map<Car>(dto);
                
                if (dto.Image != null)
                {
                    var imageResult = await _storageService.UploadImageToStorage(_currentUserService.UserId, dto.Image);
                    if (imageResult != null) newCar.Image = imageResult.Name;
                }

                var result = await _carService.AddCar(newCar, _currentUserService.UserId);
                if (result != null)
                    return CreatedAtAction(nameof(Get), new {carId = result.Id},
                        _mapper.Map<CarDto>(result));

                _logger.LogError($"Something went wrong to create new car");
                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong inside AddCar action: {e.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}