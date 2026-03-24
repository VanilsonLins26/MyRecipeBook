using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Communication.Requests;

namespace MyRecipebook.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    [HttpPost]
    public IActionResult Register(RequestRegisterUserJson request) 
    {
        return Created();
    }
}
