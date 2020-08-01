using NamedRegistrations.Domain;
using NamedRegistrations.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NamedRegistrations.Application
{
    public class CarAppService2 : ICarAppService2
    {
        private readonly ICarRepository _carRepository;
        private readonly Func<CarType, ICarValidator2> _carValidatorFactory;

        public CarAppService2(ICarRepository carRepository, Func<CarType, ICarValidator2> carValidatorFactory)
        {
            _carRepository = carRepository;
            _carValidatorFactory = carValidatorFactory;
        }

        public async Task<IList<Car>> GetCarsForALongRoadTripAsync(CarType carType)
        {
            var cars = await _carRepository.GetCarsAsync(carType);

            var carValidator = _carValidatorFactory(carType);
            if (carValidator == null)
                throw new ApplicationException($"Cannot create car validation factory for {carType}");

            return carValidator.GetGoodCarsWithASpareWheel(cars);
        }
    }

    public interface ICarAppService2
    {
        Task<IList<Car>> GetCarsForALongRoadTripAsync(CarType carType);
    }
}
