using programming009.LibraryManagement.Core.DataAccessLayer.SqlServer;
using programming009.LibraryManagement.Core.Domain.Repositories;
using programming009.LibraryManagement.WebApi.Middlewares;
using programming009.LibraryManagement.WebApi.Services;
using programming009.LibraryManagement.WebApi.Services.Abstract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

string connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddScoped<IUnitOfWork>(x => new SqlUnitOfWork(connectionString));

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = string.Empty;
    c.SwaggerEndpoint("swagger/v1/swagger.json", "v1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.Run();
