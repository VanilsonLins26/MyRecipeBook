using Mapster;
using MyRecipeBook.Application.Services.Cryptography;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Response;
using MyRecipeBook.Domain.Entities;
using MyRecipeBook.Domain.Repositories;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Exceptions;
using MyRecipeBook.Exceptions.ExceptionBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{

    private readonly IUserWriteOnlyRepository _writeOnlyRepository;
    private readonly IUserReadOnlyRepository _readOnlyRepository;
    private readonly PasswordEncrypter _passwordEncrypter;
    private readonly IUnitOfWork _uof;

    public RegisterUserUseCase(IUserWriteOnlyRepository writeOnlyRepository,
        IUserReadOnlyRepository readOnlyRepository,
        PasswordEncrypter passwordEncrypter,
        IUnitOfWork uof)
    {
        _writeOnlyRepository = writeOnlyRepository;
        _readOnlyRepository = readOnlyRepository;
        _passwordEncrypter = passwordEncrypter;
        _uof = uof;
    }

    public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
    {

        await Validate(request);

        var user = request.Adapt<Domain.Entities.User>();
        user.Password = _passwordEncrypter.Encrypt(user.Password);

        await _writeOnlyRepository.Add(user);

        await _uof.Commit();

        return new ResponseRegisterUserJson
        {
            Name = user.Name,
            Email = user.Email,
            Password = user.Password,   

        };
    }

    private async Task Validate(RequestRegisterUserJson request)
    {
        var validator = new RegisterUserValidator();
        var result = validator.Validate(request);

        var emailExist = await _readOnlyRepository.ExistsActiveUserWithEmail(request.Email);

        if (emailExist)
            result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceMessageException.EMAIL_ALREADY_EXISTS));
        

        if(!result.IsValid)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }

    }
}
