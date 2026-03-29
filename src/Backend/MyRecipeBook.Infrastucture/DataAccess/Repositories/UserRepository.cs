using Microsoft.EntityFrameworkCore;
using MyRecipeBook.Domain.Entities;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Infrastucture.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipeBook.Infrastucture.DataAccess.Repositories;

internal class UserRepository : IUserReadOnlyRepository , IUserWriteOnlyRepository
{

    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<bool> ExistsActiveUserWithEmail(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email.Equals(email) && u.Active);
    }
}
