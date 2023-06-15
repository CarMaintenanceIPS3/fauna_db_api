using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

//using database_api.FaunaDB;
using Microsoft.OpenApi.Models;
using fauna_db_api.FaunaDB;
using fauna_db_api.Models;
using fauna_db_api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository<Car>, FaunaCarRepository>();
builder.Services.AddScoped<IRepository<User>, FaunaUserRepository>();
builder.Services.AddScoped<IFaunaClientService, FaunaClientService>();
builder.Configuration["WebServer:EnforceHttps"] = "false";

//Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    Console.WriteLine("Configuring JWT Bearer options");
    options.Authority = builder.Configuration["AUTH0_ISSUER_BASE_URL"];
    options.Audience = builder.Configuration["Auth0:Audience"];
    Console.WriteLine($"Authority: {options.Authority}");
    Console.WriteLine($"Audience: {options.Audience}");
});


//FaunaDB
var faunaDBSettings = builder.Configuration.GetSection("FaunaDB").Get<FaunaDBSettings>();
faunaDBSettings.Secret = builder.Configuration["fauna_db_api"];
builder.Services.AddSingleton(faunaDBSettings);
builder.Services.AddSingleton<FaunaClientFactory>();


//Swagger config
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FaunaNetCoreAPI", Version = "v1" });

    // Define the OAuth2 scheme that's in use (i.e. Implicit Flow)
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "oauth2"
                }
            },
            new string[] {}
        }
    });
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); // Comment out or remove this line

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowAllOrigins");

app.MapControllers();
Console.WriteLine("API started");
app.Run();