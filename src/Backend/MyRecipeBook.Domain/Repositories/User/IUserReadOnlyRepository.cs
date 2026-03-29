using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipeBook.Domain.Repositories.User;

public interface IUserReadOnlyRepository
{
    public Task<bool> ExistsActiveUserWithEmail(string email);
}
