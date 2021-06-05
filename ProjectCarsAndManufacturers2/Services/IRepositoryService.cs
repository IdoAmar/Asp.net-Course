using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectCarsAndManufacturers2.Services
{
    public interface IRepositoryService
    {
        Task<User> AddUser(User user);
        Task<UserCar> AddUserCar(UserCar userCar);
        Task DeleteUser(string userName);
        Task<IEnumerable<Car>> GetAllCarsOfUser(string userName);
        Task<Dictionary<string, User>> GetAllUsers();
        Task<IEnumerable<User>> GetAllUsersOfCar(Guid carGuid);
        Task<Dictionary<Guid, Car>> GetCarsList();
        Task<Dictionary<string, Manufacturer>> GetManufacturersList();
        Task<Car> GetSpecificCar(Guid carGuid);
        Task<Manufacturer> GetSpecificManufacturer(string name);
        Task<User> GetUserByName(string userName);
        Task<User> ModifyUser(User user);
        Task RemoveUserCar(UserCar userCar);
    }
}