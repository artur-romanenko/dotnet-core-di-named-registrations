using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NamedRegistrations.Application;
using NamedRegistrations.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NamedRegistrations.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarAppService0 _carAppService0;
        private readonly ICarAppService1 _carAppService1;
        private readonly ICarAppService2 _carAppService2;
        private readonly IMapper _mapper;
        private readonly ILogger<CarsController> _logger;

        public CarsController(
            ICarAppService0 carAppService0,
            ICarAppService1 carAppService1,
            ICarAppService2 carAppService2,
            IMapper mapper, 
            ILogger<CarsController> logger)
        {
            _carAppService0 = carAppService0;
            _carAppService1 = carAppService1;
            _carAppService2 = carAppService2;
            _mapper = mapper;
            _logger = logger;
        }

        [Route("forALongRoadTrip/v0/{carType}")]
        [HttpGet]
        public async Task<ActionResult> GetCarsForALongRoadTrip0(int carType)
        {
            _logger.LogDebug($"{nameof(GetCarsForALongRoadTrip0)} was called.");

            var cars = await _carAppService0.GetCarsForALongRoadTripAsync((CarType)carType);
            return Ok(_mapper.Map<IList<Models.Car>>(cars));
        }

        [Route("forALongRoadTrip/v1/{carType}")]
        [HttpGet]
        public async Task<ActionResult> GetCarsForALongRoadTrip1(int carType)
        {
            _logger.LogDebug($"{nameof(GetCarsForALongRoadTrip1)} was called.");

            var cars = await _carAppService1.GetCarsForALongRoadTripAsync((CarType)carType);
            return Ok(_mapper.Map<IList<Models.Car>>(cars));
        }

        [Route("forALongRoadTrip/v2/{carType}")]
        [HttpGet]
        public async Task<ActionResult> GetCarsForALongRoadTrip2(int carType)
        {
            _logger.LogDebug($"{nameof(GetCarsForALongRoadTrip2)} was called.");

            var cars = await _carAppService2.GetCarsForALongRoadTripAsync((CarType)carType);
            return Ok(_mapper.Map<IList<Models.Car>>(cars));
        }
    }
}
