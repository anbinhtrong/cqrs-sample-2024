﻿using CqrsSample.Services.DataModels;

namespace CqrsSample.Services.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly BookContext _dbContext;
    public AuthorRepository(BookContext dbContext)
    {
        _dbContext = dbContext;
    }
    public List<AuthorModel> GetAuthors(int pageSize, int page)
    {
        var list = _dbContext.Authors.Skip(pageSize * page).Take(pageSize).Select(t => new AuthorModel
        {
            FirstName = t.FirstName,
            LastName = t.LastName,
            Id = t.Id,
        }).ToList();
        return list;
    }
}
