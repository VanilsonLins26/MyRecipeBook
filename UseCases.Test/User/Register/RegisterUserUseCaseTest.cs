using CommomTestUtilities.Cryptograph;
using CommomTestUtilities.Mapper;
using CommomTestUtilities.Repositories;
using CommomTestUtilities.Requests;
using FluentAssertions;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Exceptions;
using MyRecipeBook.Exceptions.ExceptionBase;
using System.Runtime.InteropServices.Marshalling;
using Xunit;

namespace UseCases.Test.User.Register;

public class RegisterUserUseCaseTest
{

    [Fact]
    public async Task Success()
    {
        var request = RequestRegisterUserJsonBuilder.Build();

        var useCase = CreateUseCase(request.Email);


        var result = await useCase.Execute(request);


        result.Should().NotBeNull();
        result.Name.Should().Be(request.Name);
    }

    private RegisterUserUseCase CreateUseCase(string? email = null)
    {
        var passwordEncripter = PasswordEncripterBuilder.Build();

        var writeRepository = UserWriteOnlyRepositoryBuilder.Build();
        var unitOfWork = UnitOfWorkBuilder.Build();
        var readRepositoryBuilder = new UserReadOnlyRepositoryBuilder();

        if (string.IsNullOrEmpty(email) == false)
            readRepositoryBuilder.ExistsActiveUserWithEmail(email);

        MapperBuilder.Configure();

        return new RegisterUserUseCase(writeRepository, readRepositoryBuilder.Build(), passwordEncripter, unitOfWork);
    }

    [Fact]
    public async Task Error_Email_Already_Registered()
    {
        var request = RequestRegisterUserJsonBuilder.Build();

        var useCase = CreateUseCase(request.Email);

        Func<Task> act = async () => await useCase.Execute(request);

        (await act.Should().ThrowAsync<ErrorOnValidationException>())
            .Where(e => e.ErrorMessages.Count == 1 
                        && e.ErrorMessages.Contains(ResourceMessageException.EMAIL_ALREADY_EXISTS));
    }

    [Fact]
    public async Task Error_Name_Empty()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Name = string.Empty;    

        var useCase = CreateUseCase();

        Func<Task> act = async () => await useCase.Execute(request);

        (await act.Should().ThrowAsync<ErrorOnValidationException>())
            .Where(e => e.ErrorMessages.Count == 1
                        && e.ErrorMessages.Contains(ResourceMessageException.NAME_EMPTY));
    }

}
