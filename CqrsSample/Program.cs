using CqrsSample.Application.Startup;
using CqrsSample.Services;
using CqrsSample.Services.Models;
using CqrsSample.Services.Startup;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API V1", Version = "v1" });
});

var serviceModule = new ServiceDependencyRegistration();
serviceModule.Register(builder.Services);

var applicationModule = new ApplicationServiceRegistration();
applicationModule.Register(builder.Services);

//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();
AddCustomerData(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

static void AddCustomerData(WebApplication app)
{
    var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetService<BookContext>();

    var authors = new List<Author>
                {
                new Author
                {
                    FirstName ="Joydip",
                    LastName ="Kanjilal",
                       Books = new List<Book>()
                    {
                        new Book { Title = "Mastering C# 8.0"},
                        new Book { Title = "Entity Framework Tutorial"},
                        new Book { Title = "ASP.NET 4.0 Programming"}
                    }
                },
                new Author
                {
                    FirstName ="Yashavanth",
                    LastName ="Kanetkar",
                    Books = new List<Book>()
                    {
                        new Book { Title = "Let us C"},
                        new Book { Title = "Let us C++"},
                        new Book { Title = "Let us C#"}
                    }
                },
                new Author
                {
                    FirstName ="Hector Malot",
                    LastName ="Kanetkar",
                    Books = new List<Book>()
                    {
                        new Book { Title = "Let us C"},
                        new Book { Title = "Let us C++"},
                        new Book { Title = "Let us C#"}
                    }
                },
                new Author
                {
                    FirstName ="Jack",
                    LastName ="Lodnon",
                    Books = new List<Book>()
                    {
                        new Book { Title = "Let us C"},
                        new Book { Title = "Let us C++"},
                        new Book { Title = "Let us C#"}
                    }
                },
                new Author
                {
                    FirstName ="Geogre",
                    LastName ="Washington",
                    Books = new List<Book>()
                    {
                        new Book { Title = "Let us C"},
                        new Book { Title = "Let us C++"},
                        new Book { Title = "Let us C#"}
                    }
                }
                };
    context.Authors.AddRange(authors);
    context.SaveChanges();
}
