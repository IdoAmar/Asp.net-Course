using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectCarsAndManufacturers2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCarsAndManufacturers2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersCarController : ControllerBase
    {
        private IRepositoryService _iRepo;

        public UsersCarController([FromServices] IRepositoryService repositoryService)
        {
            _iRepo = repositoryService;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<IEnumerable<Car>>> GetCarsOfUser(string name)
        {
            try
            {
                return Ok(await _iRepo.GetAllCarsOfUser(name));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost("")]
        public async Task<ActionResult<UserCar>> AddUser(UserCar userCar)
        {
            try
            {
                return Ok(await _iRepo.AddUserCar(userCar));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{userCar}")]
        public async Task<ActionResult> DeleteUser(UserCar userCar)
        {
            try
            {
                await _iRepo.RemoveUserCar(userCar);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

    }
}
