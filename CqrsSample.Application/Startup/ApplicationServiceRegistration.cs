using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CqrsSample.Application.Startup;

public class ApplicationServiceRegistration
{
    public void Register(IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}
