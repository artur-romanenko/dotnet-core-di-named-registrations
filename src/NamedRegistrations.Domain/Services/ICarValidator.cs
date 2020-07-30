using System.Collections.Generic;

namespace NamedRegistrations.Domain.Services
{
    public interface ICarValidator
    {
        IList<Car> GetOnlyValidCars(IList<Car> cars);
    }
}
