
using Microsoft.AspNetCore.Mvc;
using Taches.Management.Services.Interfaces;
using Taches.Management.Services.Models.DTO;

namespace Taches.Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUser _userService;
        public UsersController(IUser userService)
        {
            this._userService = userService;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest(new { Message = "Invalid user" });
            }

            var exstingUser = await _userService.authenticate(user);
            
            if(exstingUser is null)
            {
                return NotFound( new { Message = "UserName or Password are incorrectes" });
            }

        
            return Ok(new
            {
                Token = exstingUser.Tocken ,
                Message = "Login success!"
            });
        }

//        {
//  "email": "khouy@gmail.com",
//  "firstName": "Abderrazzak",
//  "lastName": "Khouy",
//  "phoneNumber": "08989878987"
//}

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest(new { Message = "Invalid data" });
            }

            if (await _userService.CheckUserEmail (user.Email))
            {
                return BadRequest(new { Message = "Email already exists!" });
            }

            if (ModelState.IsValid)
            {
               await _userService.RegisterUser(user);

                return Ok("User added successfully");
            }
            else
            {
                return BadRequest(new { Message = "Some data not valid" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _userService.GetAllUsers());
        }


        [HttpPost("OneUser")]
        public async Task<IActionResult> GetUserById([FromBody] string id)
        {
            var user = await _userService.GetUserById(id);
            if (user is null)
                return NotFound();
            return Ok(user);
        }

    }
}
