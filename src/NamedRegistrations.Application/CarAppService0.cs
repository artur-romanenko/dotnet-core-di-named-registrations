using NamedRegistrations.Domain;
using NamedRegistrations.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NamedRegistrations.Application
{
    public class CarAppService0 : ICarAppService0
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarValidatorFactory0 _carValidatorFactory;

        public CarAppService0(ICarRepository carRepository, ICarValidatorFactory0 carValidatorFactory)
        {
            _carRepository = carRepository;
            _carValidatorFactory = carValidatorFactory;
        }

        public async Task<IList<Car>> GetCarsForALongRoadTripAsync(CarType carType)
        {
            var cars = await _carRepository.GetCarsAsync(carType);

            var carValidator = _carValidatorFactory.GetValidator(carType);
            return carValidator.GetGoodCarsWithASpareWheel(cars);
        }
    }

    public interface ICarAppService0
    {
        Task<IList<Car>> GetCarsForALongRoadTripAsync(CarType carType);
    }
}
