using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipeBook.Application.UseCases.User.Register;

public interface IRegisterUserUseCase
{
    public Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request);
}
