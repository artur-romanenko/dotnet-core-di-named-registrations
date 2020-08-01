using NamedRegistrations.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NamedRegistrations.Application
{
    public interface ICarRepository
    {
        Task<IList<Car>> GetCarsAsync(CarType carType);
    }
}
