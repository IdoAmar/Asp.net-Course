using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCarsAndManufacturers2.Services
{
    public interface ICurrentUserService
    {
        Task<User> GetCurrentUser();
        Task<IEnumerable<Car>> GetUserCarsAsync();
        Task LogIn(string userName);
    }
}