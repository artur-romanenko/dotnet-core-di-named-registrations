using System.Collections.Generic;
using System.Linq;

namespace NamedRegistrations.Domain.Services
{
    public interface ICarValidator0
    {
        IList<Car> GetGoodCarsWithASpareWheel(IList<Car> cars);
    }

    public class SedanCarValidator0 : ICarValidator0
    {
        private readonly IEngineValidator _vinValidator;

        public SedanCarValidator0(IEngineValidator vinValidator)
        {
            _vinValidator = vinValidator;
        }

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

    #region Rest of the ICarValidator0 implementations

    public class SuvCarValidator0 : ICarValidator0
    {
        public IList<Car> GetGoodCarsWithASpareWheel(IList<Car> cars)
        {
            return cars.Where(x => x.Vin != "002" && x.Wheels == 5).ToList();
        }
    }

    public class CoupeCarValidator0 : ICarValidator0
    {
        public IList<Car> GetGoodCarsWithASpareWheel(IList<Car> cars)
        {
            return cars.Where(x => x.Vin != "003" && x.Wheels == 5).ToList();
        }
    }

    public class HatchbackCarValidator0 : ICarValidator0
    {
        public IList<Car> GetGoodCarsWithASpareWheel(IList<Car> cars)
        {
            return cars.Where(x => x.Vin != "004" && x.Wheels == 5).ToList();
        }
    }

    public class VanCarValidator0 : ICarValidator0
    {
        public IList<Car> GetGoodCarsWithASpareWheel(IList<Car> cars)
        {
            return cars.Where(x => x.Vin != "005" && x.Wheels == 5).ToList();
        }
    }

    #endregion
}
