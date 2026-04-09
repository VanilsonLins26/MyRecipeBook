using Microsoft.Extensions.Configuration;

namespace MyRecipeBook.Infrastucture.Extensions;

public static class ConfigurationExtension
{
    public static bool IsUnitTestEnviroment(this IConfiguration configuration)
    {
        return configuration.GetValue<bool>("InMemoryTest");
    }
}
