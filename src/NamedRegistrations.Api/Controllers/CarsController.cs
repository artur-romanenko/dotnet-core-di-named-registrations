using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NamedRegistrations.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NamedRegistrations.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarAppService _carAppService;
        private readonly IMapper _mapper;
        private readonly ILogger<CarsController> _logger;

        public CarsController(ICarAppService carAppService, IMapper mapper, ILogger<CarsController> logger)
        {
            _carAppService = carAppService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            _logger.LogDebug("Get all cars was called.");

            var cars = await _carAppService.GetAllCarsAsync();
            return Ok(_mapper.Map<IList<Models.Car>>(cars));
        }
    }
}
