using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using NLog;
using NLog.Extensions.Logging;

using programming009.LibraryManagement.Core.DataAccessLayer.SqlServer;
using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Core.Domain.Repositories;
using programming009.LibraryManagement.WebApi.Extensions;
using programming009.LibraryManagement.WebApi.Middlewares;
using programming009.LibraryManagement.WebApi.Models;
using programming009.LibraryManagement.WebApi.Options;
using programming009.LibraryManagement.WebApi.Services;
using programming009.LibraryManagement.WebApi.Services.Abstract;
using programming009.LibraryManagementWeb.Identity;

using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var logger = LogManager.Setup().LoadConfigurationFromFile("nlog.config").GetCurrentClassLogger();

logger.Log(NLog.LogLevel.Info, "Application started");

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(o =>
    {
        o.InvalidModelStateResponseFactory = f =>
        {
            var errors = f.ModelState.Values.First(v => v.Errors.Count > 0)
                        .Errors.First().ErrorMessage;

            return new BadRequestObjectResult(new ErrorResponseModel()
            {
                Message = errors
            });
        };
    });

string connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddScoped<IUnitOfWork>(x => new SqlUnitOfWork(connectionString));

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddSwaggerGen(c =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
          { jwtSecurityScheme, Array.Empty<string>() }
    });
});

builder.Services.AddFluentValidaiton();

builder.Services.AddLogging(builder =>
{
    builder.ClearProviders();
    builder.AddNLog(); // Add NLog as the logging provider
});

builder.Services.Configure<SecurityOptions>(builder.Configuration.GetSection("SecurityOptions"));

SecurityOptions options = new SecurityOptions();
builder.Configuration.GetSection("SecurityOptions").Bind(options);

byte[] keyBytes = Encoding.UTF8.GetBytes(options.Secret);

//token. JWT token -> Json Web Token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateActor = false,
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        };
    });

builder.Services.AddIdentity<User, Role>();
builder.Services.AddTransient<IUserStore<User>, UserStore>();
builder.Services.AddTransient<IRoleStore<Role>, RoleStore>();

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