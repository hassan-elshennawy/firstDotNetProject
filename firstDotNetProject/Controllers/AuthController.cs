using firstDotNetProject.DSL;
using firstDotNetProject.Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace firstDotNetProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UsersDSL _users;
        public AuthController(UsersDSL users)
        {
            _users = users;
        }
        [HttpPost("create")]
        public async Task<ActionResult<string>> CreateUser([FromBody]CreateUserRequestDTO userDTO)
        {
            return await _users.CreateUser(userDTO);
        }

        [HttpPost]
        public async Task<IActionResult> login(LoginDTO loginDto)
        {
           return Ok(loginDto);
        }

        [HttpPost("blabla")]
        public async Task<ActionResult<int>> sum([FromBody]int a, int b)
        {
            return Ok(a + b);
        }

    }
}
