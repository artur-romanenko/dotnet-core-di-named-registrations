using NamedRegistrations.Domain;
using NamedRegistrations.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NamedRegistrations.Application
{
    public class CarAppService : ICarAppService
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarValidator _carValidator;

        public CarAppService(ICarRepository carRepository, ICarValidator carValidator)
        {
            _carRepository = carRepository;
            _carValidator = carValidator;
        }

        public async Task<IList<Car>> GetAllCarsAsync()
        {
            var cars = await _carRepository.GetAllCarsAsync();

            return _carValidator.GetOnlyValidCars(cars);
        }
    }
}
