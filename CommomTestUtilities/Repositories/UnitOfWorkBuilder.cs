using Moq;
using MyRecipeBook.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommomTestUtilities.Repositories;

public class UnitOfWorkBuilder
{

    public static IUnitOfWork Build()
    {
        var mock = new Mock<IUnitOfWork>();
        return mock.Object;
    }
}
