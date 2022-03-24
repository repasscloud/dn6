using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using EngineData;
using SharedData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v2", new OpenApiInfo
    {
        Title = "OptechX API",
        Version = "v2"
    });

    // swagger auth box
    c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        In = ParameterLocation.Header,
        Description = "Basic Authorization header using the Bearer scheme."
    });
});
builder.Services.AddDbContext<EngineDataContext>(options =>
{
    options
        .UseNpgsql(builder.Configuration.GetConnectionString("DevDb"))
        .UseSnakeCaseNamingConvention()
        .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
        .EnableSensitiveDataLogging();
});
builder.Services.AddDbContext<SharedDataContext>(options =>
{
    options
        .UseNpgsql(builder.Configuration.GetConnectionString("DevDb"))
        .UseSnakeCaseNamingConvention()
        .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
        .EnableSensitiveDataLogging();
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddCors();
    builder.Services.AddControllers().AddJsonOptions(x => 
    {
        // serialize enums as strings in api responses (e.g. Role)
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v2/swagger.json", "OptechX V2");
        c.RoutePrefix = "";
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run("http://localhost:5000");
