using System.Collections.Generic;
using System.Linq;

namespace NamedRegistrations.Domain.Services
{
    public class CarValidator : ICarValidator
    {
        public IList<Car> GetOnlyValidCars(IList<Car> cars)
        {
            return cars.Where(x => x.Vin != "000").ToList();
        }
    }
}
