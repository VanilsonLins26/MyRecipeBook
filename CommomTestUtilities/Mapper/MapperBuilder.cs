using Mapster;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommomTestUtilities.Mapper;

public class MapperBuilder
{
    public static void Configure()
    {
        TypeAdapterConfig<RequestRegisterUserJson, User>
            .NewConfig()
            .Ignore(dest => dest.Password);
    }
}
