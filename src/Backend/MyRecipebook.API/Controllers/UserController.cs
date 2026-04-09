using Microsoft.AspNetCore.Mvc;

using MyRecipeBook.Application.UseCases;
using MyRecipeBook.Application.UseCases.User.Register;

using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Response;

namespace MyRecipebook.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
    public async Task<IActionResult> Register([FromBody] RequestRegisterUserJson request, [FromServices] IRegisterUserUseCase useCase)
    {

        var result = await useCase.Execute(request);



        return Created(string.Empty, result);
    }
}
