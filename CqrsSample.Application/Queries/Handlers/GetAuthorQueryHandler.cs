using CqrsSample.Services.DataModels;
using CqrsSample.Services.Repositories;
using MediatR;

namespace CqrsSample.Application.Queries.Handlers
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<AuthorModel>>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAuthorQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<AuthorModel>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            return _authorRepository.GetAuthors(request.PageSize, request.PageIndex);
        }
    }
}
