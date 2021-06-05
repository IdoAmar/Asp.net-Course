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
    public class ManufacturersController : ControllerBase
    {
        private IRepositoryService _iRepo;

        public ManufacturersController([FromServices] IRepositoryService repositoryService)
        {
            _iRepo = repositoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Manufacturer>>> GetManufacturers() => Ok((await _iRepo.GetManufacturersList()).Values.ToList());

        [HttpGet("{name}")]
        public async Task<ActionResult<Manufacturer>> GetManufacturer(string name)
        {
            try
            {
                return Ok(await _iRepo.GetSpecificManufacturer(name));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
