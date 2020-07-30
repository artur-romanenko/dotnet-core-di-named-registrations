using NamedRegistrations.Application;
using NamedRegistrations.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NamedRegistrations.Infrastructure
{
    public class CarRepository : ICarRepository
    {
        public Task<IList<Car>> GetAllCarsAsync()
        {
            IList<Car> cars = new List<Car> { new Car("123"), new Car("456") };
            return Task.FromResult(cars);
        }
    }
}
