using NamedRegistrations.Domain;
using NamedRegistrations.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NamedRegistrations.Application
{
    public class CarAppService1 : ICarAppService1
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarValidatorFactory1 _carValidatorFactory;

        public CarAppService1(ICarRepository carRepository, ICarValidatorFactory1 carValidatorFactory)
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

    public interface ICarAppService1
    {
        Task<IList<Car>> GetCarsForALongRoadTripAsync(CarType carType);
    }
}
