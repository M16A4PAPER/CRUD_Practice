using CRUD_Practice.CacheManager.Caches;
using CRUD_Practice.DBMySql.Main;
using CRUD_Practice.Models.Interfaces.CacheManagers;
using CRUD_Practice.Models.Interfaces.DBFactory;
using CRUD_Practice.Models.Interfaces.Services;
using CRUD_Practice.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IDatabaseFactory, MySqlDatabaseFactory>();
builder.Services.AddScoped<IDepartmentsService, DepartmentsService>();
builder.Services.AddScoped<IEmployeesService, EmployeesService>();

builder.Services.AddMemoryCache();
builder.Services.AddScoped<IDepartmentsCache, DepartmentsCache>();
builder.Services.AddScoped<IEmployeesCache, EmployeesCache>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
