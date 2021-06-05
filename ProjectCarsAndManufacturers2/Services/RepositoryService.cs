using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCarsAndManufacturers2.Services
{
    public class RepositoryService : IRepositoryService
    {
        Dictionary<Guid, Car> _carsList;
        Dictionary<string, Manufacturer> _manufacturersList;
        Dictionary<string, User> _usersList = new();
        HashSet<UserCar> _userCarList = new();
        IDataReaderService _dataReader;

        public RepositoryService(IDataReaderService dataReader)
        {
            _dataReader = dataReader;
        }

        // Get Cars list and specific car

        public async Task<Dictionary<Guid, Car>> GetCarsList() =>
            _carsList ??= (await _dataReader.GetCarsEnumerator()).ToDictionary(c => c.Id);

        public async Task<Car> GetSpecificCar(Guid carGuid) =>
            (await GetCarsList())[carGuid];

        // Get Manufacturers list and specific manufacturer

        public async Task<Dictionary<string, Manufacturer>> GetManufacturersList() =>
            _manufacturersList ??= (await _dataReader.GetManufacturersEnumerator()).ToDictionary(c => c.Name);

        public async Task<Manufacturer> GetSpecificManufacturer(string name) =>
            (await GetManufacturersList())[name];

        // users CRUD

        public Task<User> GetUserByName(string userName) =>
            Task.FromResult(_usersList[userName]);

        public Task<Dictionary<string, User>> GetAllUsers() =>
            Task.FromResult(_usersList);

        public Task<User> AddUser(User user)
        {
            if (_usersList.ContainsKey(user.UserName))
                throw new ArgumentException($"User with {user.UserName} already exist");
            else
            {
                _usersList.Add(user.UserName, user);
                return Task.FromResult(user);
            }
        }

        public Task<User> ModifyUser(User user)
        {
            if (!_usersList.ContainsKey(user.UserName))
                throw new ArgumentException($"User {user.UserName} does not exist");
            _usersList[user.UserName] = user;
            return Task.FromResult(user);
        }

        public Task DeleteUser(string userName)
        {
            if (!_usersList.ContainsKey(userName))
                throw new ArgumentException($"Username {userName} does not exist");

            _usersList.Remove(userName);
            _userCarList.RemoveWhere(u => u.UserName == userName);
            return Task.CompletedTask;
        }

        // UserCar CRUD

        public async Task<IEnumerable<Car>> GetAllCarsOfUser(string userName)
        {
            if (_carsList is null)
                await GetCarsList();
            return _userCarList.Where(uc => uc.UserName == userName).Select(uc => _carsList[uc.CarGuid]);
        }

        public Task<IEnumerable<User>> GetAllUsersOfCar(Guid carGuid)
        {
            return Task.FromResult(_userCarList.Where(uc => uc.CarGuid == carGuid).Select(uc => _usersList[uc.UserName]));
        }

        public Task<UserCar> AddUserCar(UserCar userCar)
        {
            if (_userCarList.Contains(userCar))
                throw new ArgumentException($"UserCar record  with user : {userCar.UserName} with car guid : {userCar.CarGuid} already exist");
            if (!_usersList.ContainsKey(userCar.UserName))
                throw new ArgumentException($"User {userCar.UserName} does not exist");
            if (!_carsList.ContainsKey(userCar.CarGuid))
                throw new ArgumentException($"Car with car guid {userCar.CarGuid} does not exist");

            _userCarList.Add(userCar);
            return Task.FromResult(userCar);
        }

        public Task RemoveUserCar(UserCar userCar)
        {
            if (!_userCarList.Contains(userCar))
                throw new ArgumentException($"UserCar record does not contain a record with user : {userCar.UserName}" +
                                            $" and car guid : {userCar.CarGuid}");
            _userCarList.Remove(userCar);
            return Task.CompletedTask;
        }


    }
}
