//using BuberDinner.API.Filters;
//using BuberDinner.API.Middleware;
using BuberDinner.API.Errors;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddSingleton<ProblemDetailsFactory,BuberDinnerProblemDetailsFactory>();

var app = builder.Build();

//app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
