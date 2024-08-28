using FlashcardsAPI.CoreServices.CoreData;
using FlashcardsAPI.CoreServices.ServiceInterface;
using FlashcardsAPI.Data;
using FlashcardsAPI.Infrastructure.DataRepository;
using FlashcardsAPI.Infrastructure.RepositoryInterface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]))
        };
    });

builder.Services.AddControllers();

builder.Services.AddDbContext<FlashcardsContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("FlashcardsConnection")));

builder.Services.AddTransient<IFlashcardsRepo, FlashcardsRepo>();
builder.Services.AddTransient<IFlashcardsService, FlashcardsService>();
builder.Services.AddTransient<IUsersRepo, UsersRepo>();
builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddScoped<IJWTService, JWTService>();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
