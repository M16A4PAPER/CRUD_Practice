using CRUD_Practice.CacheManager.Caches;
using CRUD_Practice.DBMySql.Main;
using CRUD_Practice.Models.Constants;
using CRUD_Practice.Models.Interfaces.CacheManagers;
using CRUD_Practice.Models.Interfaces.DBFactory;
using CRUD_Practice.Models.Interfaces.Services;
using CRUD_Practice.Models.Models;
using CRUD_Practice.Services.Auth;
using CRUD_Practice.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(builder.Configuration)
                    .Enrich.FromLogContext()
                    .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} [{RequestMethod} {RequestPath} User:{UserId} IP:{ClientIP}] {Exception}{NewLine}")
                    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.
builder.Services.AddSingleton<IDatabaseFactory, MySqlDatabaseFactory>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IDepartmentsService, DepartmentsService>();
builder.Services.AddScoped<IEmployeesService, EmployeesService>();

builder.Services.AddMemoryCache();
builder.Services.AddScoped<IDepartmentsCache, DepartmentsCache>();
builder.Services.AddScoped<IEmployeesCache, EmployeesCache>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Jwt Authentication Configuration
var jwtConfig = builder.Configuration.GetSection("Jwt");
var keyString = jwtConfig["Key"];
if (string.IsNullOrWhiteSpace(keyString))
{
    throw new Exception("JWT Key is not configured.");
}

var key = Encoding.UTF8.GetBytes(keyString);

//Claim Mapping Reset
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

//Authentication Scheme Setup
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtConfig["Issuer"],
            ValidAudience = jwtConfig["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ClockSkew = TimeSpan.Zero
        };

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = async context =>
            {
                context.NoResult();

                if (!context.Response.HasStarted)
                {
                    context.Response.StatusCode = StatusCodes.Status200OK;
                    context.Response.ContentType = "application/json";

                    var result = JsonSerializer.Serialize(new
                    {
                        status = AppStatusCodes.AccessTokenExpired,
                        message = "Access Token Expired",
                        data = Array.Empty<object>()
                    });

                    await context.Response.WriteAsync(result);
                    await context.Response.CompleteAsync();
                }

            },

            OnChallenge = async context =>
            {
                context.HandleResponse();

                // This handles cases where token is missing or rejected by validation
                if (!context.Response.HasStarted)
                {
                    context.Response.StatusCode = StatusCodes.Status200OK;
                    context.Response.ContentType = "application/json";

                    var result = JsonSerializer.Serialize(new
                    {
                        status = AppStatusCodes.AccessTokenExpired,
                        message = "Access token expired or missing",
                        data = Array.Empty<object>()
                    });

                    await context.Response.WriteAsync(result);
                    await context.Response.CompleteAsync();
                }
            }
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "1.0.0",
        Title = "CRUD_Practice API V1",
        Description = "Version 1 of CRUD_Practice API"
    }); ;

    // Swagger + JWT support
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Enter the token.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
