using CosmosCRUD.Models;
using CosmosCRUD.Services;
using Microsoft.AspNetCore.Mvc;


namespace CosmosCRUD.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(ILogger<UserController> logger, IUserService userService) : ControllerBase
{
    private readonly ILogger<UserController> _logger = logger;

    private IUserService _userService = userService;

    [HttpGet()]
    [Route("{id}")]
    public IActionResult Get(string id)
    {
        return Ok(_userService.ReadUser(id));
    }

    [HttpPost()]
    [Route("")]
    public IActionResult Post([FromBody] User user)
    {
        return Ok(_userService.CreateUser(user));
    }

    [HttpPut()]
    [Route("{id}")]
    public IActionResult Update(string id, [FromBody] User user)
    {
        if (id!= user.UserID) return BadRequest();
        return Ok(_userService.UpdateUser(user));
    }

    [HttpDelete()]
    [Route("{id}")]
    public IActionResult Delete(string id)
    {
        return Ok(_userService.DeleteUser(id));
    }
}