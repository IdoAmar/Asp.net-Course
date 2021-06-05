using Microsoft.AspNetCore.Mvc;
using ProjectCarsAndManufacturers2.Services;
using System.Threading.Tasks;

namespace ProjectCarsAndManufacturers2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IRepositoryService _iRepo;

        public UsersController([FromServices] IRepositoryService repositoryService)
        {
            _iRepo = repositoryService;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<User>> GetUser(string name)
        {
            try
            {
                return Ok(await _iRepo.GetUserByName(name));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPost("")]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            try
            {
                return Ok(await _iRepo.AddUser(user));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("{userName}")]
        public async Task<ActionResult> DeleteUser(string userName)
        {
            try
            {
                await _iRepo.DeleteUser(userName);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }


    }
}
