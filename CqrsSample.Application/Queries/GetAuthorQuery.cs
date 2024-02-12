using CqrsSample.Services.DataModels;
using MediatR;

namespace CqrsSample.Application.Queries;

public class GetAuthorQuery : IRequest<List<AuthorModel>>
{
    public int PageSize { get; set; }
    public int PageIndex { get; set; } = 10;
}
