using NamedRegistrations.Application;
using NamedRegistrations.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamedRegistrations.Infrastructure
{
    public class CarRepository : ICarRepository
    {
        private static readonly IReadOnlyList<Car> _cars = new List<Car>
            {
                new Car("123", CarType.Sedan, wheels: 5),
                new Car("456", CarType.Sedan, wheels: 5),
                new Car("789", CarType.Coupe, wheels: 5),
                new Car("012", CarType.Hatchback, wheels: 5),
                new Car("345", CarType.Suv, wheels: 5),
                new Car("678", CarType.Van, wheels: 5),
                new Car("901", CarType.Sedan, Car.GoodEngine, 4),
                new Car("901", CarType.Sedan, Car.BadEngine, 5),
            };

        public Task<IList<Car>> GetCarsAsync(CarType carType)
        {
            IList<Car> cars = _cars.Where(x => x.Type == carType).ToList();
            return Task.FromResult(cars);
        }
    }
}
