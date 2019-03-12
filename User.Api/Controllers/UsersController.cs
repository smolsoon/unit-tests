using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using User.Api.Commands;
using User.Api.Services;

namespace User.Api.Controllers {

    [Route ("api/[controller]")]
    public class UsersController : Controller {
        private readonly IUserService _UserService;
        public UsersController (IUserService UserService) {
            _UserService = UserService;
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> Get (Guid id) => Json (await _UserService.GetUserAsync (id));

        [HttpGet]
        public async Task<IActionResult> GetPeople () => Json (await _UserService.GetAllUserAsync ());

        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] CreateUser command) {
            command.Id = Guid.NewGuid ();
            await _UserService.CreateAsync (command.Id, command.Firstname, command.Lastname, command.Age);
            return Created ($"/User/{command.Id}", null);
        }
    }

}