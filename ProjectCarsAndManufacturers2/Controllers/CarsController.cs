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
    public class CarsController : ControllerBase
    {
        private IRepositoryService _iRepo;

        public CarsController([FromServices] IRepositoryService repositoryService)
        {
            _iRepo = repositoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Car>>> GetCars([FromServices] ICurrentUserService currentUserService, [FromQuery] string manufacturer = null)
        {

            var res = currentUserService.GetCurrentUser() is null ?
                     (await _iRepo.GetCarsList()).Values :
                     await _iRepo.GetAllCarsOfUser((await currentUserService.GetCurrentUser()).UserName);
            if (manufacturer is not null)
            {
                return res.Where(c => c.Division == manufacturer).ToList();
            }
            else
            {
                return res.ToList();
            }
        }


        [HttpGet("{guid}")]
        public async Task<ActionResult<Car>> GetCar(Guid guid)
        {
            try
            {
                return Ok(await _iRepo.GetSpecificCar(guid));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
