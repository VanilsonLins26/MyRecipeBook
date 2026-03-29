using Microsoft.AspNetCore.Mvc;
<<<<<<< Updated upstream
=======
using MyRecipeBook.Application.UseCases;
using MyRecipeBook.Application.UseCases.User.Register;
>>>>>>> Stashed changes
using MyRecipeBook.Communication.Requests;

namespace MyRecipebook.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{

    [HttpPost]
<<<<<<< Updated upstream
    public IActionResult Register(RequestRegisterUserJson request) 
    {
        return Created();
=======
    public async Task<IActionResult> Register([FromBody] RequestRegisterUserJson request, [FromServices] IRegisterUserUseCase useCase)
    {

        var result = await useCase.Execute(request);



        return Created(string.Empty, result);
>>>>>>> Stashed changes
    }
}
