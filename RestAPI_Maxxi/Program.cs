using Microsoft.EntityFrameworkCore;
using RestAPI_Maxxi.Data;
using RestAPI_Maxxi.Middleware;
using RestAPI_Maxxi.Services;

var builder = WebApplication.CreateBuilder(args);

var builderConfiguration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

IConfiguration configuration = builderConfiguration.Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IConfiguration>(configuration);
builder.Services.AddScoped<IEmpleados, EmpleadosService>();
builder.Services.AddScoped<IEmpleadosRepositoryData, EmpleadosRepositoryData>();
builder.Services.AddScoped<IBeneficiario, BeneficiariosService>();
builder.Services.AddScoped<IBeneficiarioRepositoryData, BeneficiarioRepositoryData>();

builder.Services.AddDbContext<DataDBContext>(options =>
{
    // Obtén la cadena de conexión y configura el proveedor SQL Server
    var connectionString = configuration.GetConnectionString("SQLServerConnection");
    options.UseSqlServer(connectionString);
});

var app = builder.Build();
UseExceptionHandler.Configure(app);

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
