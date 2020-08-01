using System;
using System.Collections.Generic;
using System.Linq;

namespace NamedRegistrations.Domain.Services
{
    public class CarValidatorFactory1 : ICarValidatorFactory1
    {
        private readonly IEnumerable<ICarValidator1> _carValidators;

        public CarValidatorFactory1(IEnumerable<ICarValidator1> carValidators)
        {
            _carValidators = carValidators;
        }

        public ICarValidator1 GetValidator(CarType carType)
        {
            var carValidator = _carValidators.SingleOrDefault(x => x.CarType == carType);
            if (carValidator == null)
                throw new ApplicationException($"Cannot create car validation factory for {carType}");

            return carValidator;
        }
    }

    public interface ICarValidatorFactory1
    {
        ICarValidator1 GetValidator(CarType carType);
    }
}
