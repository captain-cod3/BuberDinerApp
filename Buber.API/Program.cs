using Buber.API.Filters;
using Buber.API.Middleware;
using Buber.Application;
using Buber.Infrastructure;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplication().AddInfrastructure(builder.Configuration);

// Add services to the container.

builder.Services.AddControllers(options=>options.Filters.Add<ErrorHandlingAttribute>());


var app = builder.Build();

//app.UseMiddleware<ErrorHandlingMiddleware>(); // approach 1 for exception handling.
app.UseHttpsRedirection();

app.MapControllers();

app.Run();
