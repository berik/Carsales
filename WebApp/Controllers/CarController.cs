using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Interfaces.IData;
using Core.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
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

        public CarController(ILogger<CarController> logger, IMapper mapper, IUnitOfWork unitOfWork, ICurrentUserService currentUserService)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation($"Retrieve all cars by userID: {_currentUserService.UserId}");
            var cars = await _unitOfWork.CarRepository.GetAllAsync(_currentUserService.UserId);
            var result = _mapper.Map<List<CarDto>>(cars);
            return Ok(result);
        }
    }
}