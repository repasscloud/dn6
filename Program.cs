using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;  //👈 new code
using EngineData;
using SharedData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//👇 new code
// 1. Add Authentication Services
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = "https://dev-1jeztw84.au.auth0.com/";
    options.Audience = "https://spiral-starlet4/api";
});
//👆 new code


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

    //👇 new code
    var securitySchema = new OpenApiSecurityScheme
    {
        Description = "Using the Authorization header with the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        Reference = new OpenApiReference
        {
        Type = ReferenceType.SecurityScheme,
        Id = "Bearer"
        }
    };
    c.AddSecurityDefinition("Bearer", securitySchema);

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            { securitySchema, new[] { "Bearer" } }
        });
    //👆 new code
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


// customers interface context
    //webApplicationBuilder.Services.AddDbContext<ApplicationDatasContext>(options =>
    //{
    //    options.UseNpgsql(webApplicationBuilder.Configuration.GetConnectionString("DevDb"));
    //});


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

// 2. Enable authentication middleware
app.UseAuthentication();  //👈 new code

app.UseAuthorization();

app.MapControllers();

app.Run("http://localhost:4000");
