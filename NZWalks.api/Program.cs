using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NZWalks.api.Configuration;
using NZWalks.Api.Business.Services;
using NZWalks.Api.Data;
using NZWalks.Api.Data.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Use Entity Framework
builder.Services.AddDbContext<ApiDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDBConnection")));

// Use AutoMapper

builder.Services.AddAutoMapper(typeof(MyMapperProfile));

// Use JWT Tokens

InjectJWTAuthorisation(builder);

builder.Services.AddAuthorization();

//Use dependency injection

builder.Services.AddScoped<IWalkRepo, WalkRepository>();
builder.Services.AddScoped<WalkService, WalkService>();

builder.Services.AddScoped<IRegionRepo, RegionRepository>();
builder.Services.AddScoped<RegionService, RegionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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


static void InjectJWTAuthorisation(WebApplicationBuilder builder)
{
    var config = builder.Configuration;
    // Add JWT Bearer Authentication
    builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = config["JwtSettings: Issuer"],
            ValidAudience = config["JwtSettings: Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true
        };
    });
}