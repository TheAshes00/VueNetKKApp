using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using VueNetKKApp.Server.Context;

var builder = WebApplication.CreateBuilder(args);

//                                                          // Var to anable cross origin request
var strspecifiedOrigins = "_specifiedOrigins";

//                                                          // Var to get connect to MySQL DB
var strConnectionString = builder.Configuration.GetConnectionString("KKApiDatabase");

//                                                          // Get Configuration from appsettings 
var jwtSettings = builder.Configuration.GetSection("JWTSettings");
var key = jwtSettings["Key"];
var issuer = jwtSettings["Issuer"];
var audience = jwtSettings["Audience"];

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//                                                          // Add DBContext To MySQL before building app
builder.Services.AddDbContext<DonutsContext>(options =>
{
    options.UseMySql(strConnectionString, ServerVersion.AutoDetect(strConnectionString));
});

//                                                          // Add JWT Token configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
        };
    });


builder.Services.AddSwaggerGen(c =>
{
    // Aquí puedes agregar una configuración de seguridad para Swagger (opcional)
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingrese 'Bearer' [espacio] y luego el token JWT en el campo de texto a continuación.\n\nEjemplo: \"Bearer abcdef12345\""
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new string[] {}
        }
    });
    //                                                      //Allow $In schema in controllers
    c.CustomSchemaIds(type => type.FullName);
});

builder.Services.AddCors(options =>
    options.AddPolicy(strspecifiedOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:5173");
            policy.AllowAnyHeader().AllowAnyMethod();
        })
);

builder.Services.AddHttpClient();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(strspecifiedOrigins);
app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();



app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
