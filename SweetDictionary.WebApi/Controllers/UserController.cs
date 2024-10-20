using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Models.Users;
using SweetDictionary.Service.Abstract;

namespace SweetDictionary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] CreateUserRequestDto dto)
        {
            var result = _userService.Add(dto);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdateUserRequestDto dto)
        {
            var result = _userService.Update(dto);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(long id)
        {
            var result = _userService.Delete(id);
            return Ok(result);
        }

        [HttpGet("getById/{id}")]
        public IActionResult GetById(long id)
        {
            var result = _userService.GetById(id);
            return Ok(result);
        }

        [HttpGet("getByEmail/{email}")]
        public IActionResult GetByEmail(string email)
        {
            var result = _userService.GetByEmail(email);
            return Ok(result);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            return Ok(result);
        }

        [HttpGet("search/{username}")]
        public IActionResult GetAllByUsernameContains(string username)
        {
            var result = _userService.GetAllByUsernameContains(username);
            return Ok(result);
        }
    }
}