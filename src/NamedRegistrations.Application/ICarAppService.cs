using NamedRegistrations.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NamedRegistrations.Application
{
    public interface ICarAppService
    {
        Task<IList<Car>> GetAllCarsAsync();
    }
}
