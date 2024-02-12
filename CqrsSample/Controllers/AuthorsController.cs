using CqrsSample.Application.Queries;
using CqrsSample.Services.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsSample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuthorsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<ActionResult<List<Author>>> Get(int pageSize, int pageIndex)
    {
        var authorRequest = new GetAuthorQuery
        {
            PageIndex = pageIndex,
            PageSize = pageSize
        };
        var result = await _mediator.Send(authorRequest);
        return Ok(result);
    }
}
