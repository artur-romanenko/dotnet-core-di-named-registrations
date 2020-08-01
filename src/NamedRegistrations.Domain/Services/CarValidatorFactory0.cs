using Microsoft.Extensions.DependencyInjection;
using System;

namespace NamedRegistrations.Domain.Services
{
    public class CarValidatorFactory0 : ICarValidatorFactory0
    {
        // UNWANTED dependency on Microsoft.Extensions.DependencyInjection in Domain!
        private readonly IServiceProvider _serviceProvider;

        public CarValidatorFactory0(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICarValidator0 GetValidator(CarType carType)
        {
            ICarValidator0 carValidator = null;
            switch (carType)
            {
                case CarType.Sedan:
                    carValidator = _serviceProvider.GetService<SedanCarValidator0>();
                    break;
                case CarType.Coupe:
                    carValidator = _serviceProvider.GetService<CoupeCarValidator0>();
                    break;
                case CarType.Hatchback:
                    carValidator = _serviceProvider.GetService<HatchbackCarValidator0>();
                    break;
                case CarType.Suv:
                    carValidator = _serviceProvider.GetService<SuvCarValidator0>();
                    break;
                case CarType.Van:
                    carValidator = _serviceProvider.GetService<VanCarValidator0>();
                    break;
            }

            if (carValidator == null)
                throw new ApplicationException($"Cannot create car validation factory for {carType}");

            return carValidator;
        }
    }

    public interface ICarValidatorFactory0
    {
        ICarValidator0 GetValidator(CarType carType);
    }
}
