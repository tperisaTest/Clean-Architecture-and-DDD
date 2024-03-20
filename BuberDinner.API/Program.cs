//using BuberDinner.API.Filters;
//using BuberDinner.API.Middleware;
using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

//app.UseMiddleware<ErrorHandlingMiddleware>();
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
