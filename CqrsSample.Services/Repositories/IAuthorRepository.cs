using CqrsSample.Services.DataModels;

namespace CqrsSample.Services.Repositories;

public interface IAuthorRepository
{
    public List<AuthorModel> GetAuthors(int pageSize, int page);
}
