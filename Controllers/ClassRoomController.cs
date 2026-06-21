using DemoAPI.Models;
using DemoAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassRoomController : ControllerBase
    {
        private readonly IClassRoomRepository _repository;

        public ClassRoomController(IClassRoomRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClassRoom>>> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }



    }
}
