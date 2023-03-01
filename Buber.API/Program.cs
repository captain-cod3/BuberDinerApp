using Buber.Application;
using Buber.Application.Services.Authentication;
using Buber.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplication().AddInfrastructure();

// Add services to the container.

builder.Services.AddControllers();


var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
