using CqrsSample.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CqrsSample.Services.Startup;

public class ServiceDependencyRegistration
{
    public void Register(IServiceCollection services)
    {
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddDbContext<BookContext>(o => o.UseInMemoryDatabase("MyDatabase"));
    }
}
