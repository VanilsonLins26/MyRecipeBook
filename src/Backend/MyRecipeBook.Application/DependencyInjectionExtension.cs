using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Application.Services.Cryptography;
using MyRecipeBook.Application.UseCases.User.Register;

namespace MyRecipeBook.Application;

public static class DependencyInjectionExtension
{

    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        AddUseCase(services);
        AddPasswordsEncrypter(services, configuration);
    }

    private static void AddUseCase(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase> ();   
    }

    private static void AddPasswordsEncrypter(IServiceCollection services, IConfiguration configuration)
    {
        var additionalKey = configuration.GetSection("Settings:Password:AdditionalKey").Value;
        services.AddScoped(options => new PasswordEncrypter(additionalKey!));
    }
}
