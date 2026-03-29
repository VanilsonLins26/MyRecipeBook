using MyRecipeBook.Domain.Repositories;
using MyRecipeBook.Infrastucture.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyRecipeBook.Infrastucture.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task Commit() => await _context.SaveChangesAsync();
}
