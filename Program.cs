// using System.Text.Json.Serialization;
using rexfinder_api.Migrations;
using rexfinder_api.Repositories;
using rexfinder_api.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

/////////////// NOT USING IN V1 OF AUTH ////////////////////////////
// using WebApi.Authorization;
// using WebApi.Entities;
// using WebApi.Helpers;
// using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// connecting Controllers
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// Adding Swagger to test if we want it
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "l11_tokens", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
        In = ParameterLocation.Header, 
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey 
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    { 
        new OpenApiSecurityScheme 
        { 
        Reference = new OpenApiReference 
        { 
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer" 
        } 
        },
        new string[] { } 
        } 
    });
});


// DI for SQL server and Migrations
builder.Services.AddSqlite<MyPlacesDbContext>("Data Source=RexfinderDb.db");

// DI for Auth Service and JWT
builder.Services.AddScoped<IAuthService, AuthService>();

// DI for all other Repositories
builder.Services.AddScoped<IUserV1Repository, UserV1Repository>();
builder.Services.AddScoped<IMyPlaceRepository, MyPlaceRepository>();
builder.Services.AddScoped<IDonutShopRepository, DonutShopRepository>();
builder.Services.AddScoped<IExperiencesRepository, ExperiencesRepository>();
builder.Services.AddScoped<IForgotPasswordRepository,ForgotPasswordRepository>();
builder.Services.AddScoped<IEmailRepository,EmailRepository>();

// DI for JWT Authentication & Token builder
var secretKey = builder.Configuration["TokenSecret"];

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = true;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateLifetime = false,
        RequireExpirationTime = false,
        ClockSkew = TimeSpan.Zero,
        ValidateIssuerSigningKey = true
    };
});
// configure strongly typed settings object
    builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


// add services to DI container
/////////////// NOT USING IN V1 OF AUTH ////////////////////////////
// {
//     var services = builder.Services;
//     var env = builder.Environment;
 
//     services.AddDbContext<DataContext>();
//     services.AddCors();
//     services.AddControllers()
//         .AddJsonOptions(x => x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);

//     // configure strongly typed settings object
//     services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

//     // configure DI for application services
//     services.AddScoped<IJwtUtils, JwtUtils>();
//     services.AddScoped<IUserService, UserService>();
// }

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// add hardcoded test user to db on startup
/////////////// NOT USING IN V1 OF AUTH ////////////////////////////
// using (var scope = app.Services.CreateScope())
// {
//     var context = scope.ServiceProvider.GetRequiredService<DataContext>();    
//     var testUser = new User
//     {
//         FirstName = "Test",
//         LastName = "User",
//         Username = "test",
//         PasswordHash = BCrypt.Net.BCrypt.HashPassword("test")
//     };
//     context.Users.Add(testUser);
//     context.SaveChanges();
// }

// configure HTTP request pipeline
// {
    // global cors policy
    app.UseCors(x => x
        .SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());

    // global error handler
    /////////////// NOT USING IN V1 OF AUTH ////////////////////////////
    // app.UseMiddleware<ErrorHandlerMiddleware>();

    // custom jwt auth middleware
    /////////////// NOT USING IN V1 OF AUTH ////////////////////////////
    // app.UseMiddleware<JwtMiddleware>();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
// }

// app.Run("http://localhost:4000");

app.Run();
