using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCarsAndManufacturers2.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        User _currentUser;
        private IRepositoryService _iRepo;

        public CurrentUserService(IRepositoryService repositoryService)
        {
            _iRepo = repositoryService;
        }

        public async Task LogIn(string userName)
        {
            if (!(await _iRepo.GetAllUsers()).ContainsKey(userName))
                throw new InvalidOperationException("User does not exist");

            _currentUser = await _iRepo.GetUserByName(userName);
        }

        public Task<User> GetCurrentUser()
        {
            if (_currentUser is null)
                throw new NullReferenceException("There is no user logged in");
            return Task.FromResult(_currentUser);
        }

        public async Task<IEnumerable<Car>> GetUserCarsAsync()
        {
            if (_currentUser is null)
                throw new NullReferenceException("There is no user logged in");
            return await _iRepo.GetAllCarsOfUser(_currentUser.UserName);
        }

    }
}
