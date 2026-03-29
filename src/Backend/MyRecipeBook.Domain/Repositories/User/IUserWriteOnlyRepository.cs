using MyRecipeBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipeBook.Domain.Repositories.User;

public interface IUserWriteOnlyRepository
{
    public Task Add(Entities.User user);
}
