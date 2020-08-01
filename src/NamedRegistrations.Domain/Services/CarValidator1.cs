using System.Collections.Generic;
using System.Linq;

namespace NamedRegistrations.Domain.Services
{
    public interface ICarValidator1
    {
        CarType CarType { get; }

        IList<Car> GetGoodCarsWithASpareWheel(IList<Car> cars);
    }

    public class SedanCarValidator1 : ICarValidator1
    {
        private readonly IEngineValidator _vinValidator;

        public SedanCarValidator1(IEngineValidator vinValidator)
        {
            _vinValidator = vinValidator;
        }

        public CarType CarType => CarType.Sedan;

        public IList<Car> GetGoodCarsWithASpareWheel(IList<Car> cars)
        {
            // Complex CarType-specific check logic
            return cars
                .Where(x =>
                    _vinValidator.IsEngineInAGoodCondition(x.EngineCondition)
                    && x.Wheels == 5)
                .ToList();
        }
    }

    #region Rest of the ICarValidator1 implementations

    public class SuvCarValidator1 : ICarValidator1
    {
        public CarType CarType => CarType.Suv;

        public IList<Car> GetGoodCarsWithASpareWheel(IList<Car> cars)
        {
            return cars.Where(x => x.Vin != "002" && x.Wheels == 5).ToList();
        }
    }

    public class CoupeCarValidator1 : ICarValidator1
    {
        public CarType CarType => CarType.Coupe;

        public IList<Car> GetGoodCarsWithASpareWheel(IList<Car> cars)
        {
            return cars.Where(x => x.Vin != "003" && x.Wheels == 5).ToList();
        }
    }

    public class HatchbackCarValidator1 : ICarValidator1
    {
        public CarType CarType => CarType.Hatchback;

        public IList<Car> GetGoodCarsWithASpareWheel(IList<Car> cars)
        {
            return cars.Where(x => x.Vin != "004" && x.Wheels == 5).ToList();
        }
    }

    public class VanCarValidator1 : ICarValidator1
    {
        public CarType CarType => CarType.Van;

        public IList<Car> GetGoodCarsWithASpareWheel(IList<Car> cars)
        {
            return cars.Where(x => x.Vin != "005" && x.Wheels == 5).ToList();
        }
    }

    #endregion
}
