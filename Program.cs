using FlashcardsAPI.CoreServices.CoreData;
using FlashcardsAPI.CoreServices.ServiceInterface;
using FlashcardsAPI.Data;
using FlashcardsAPI.Infrastructure.DataRepository;
using FlashcardsAPI.Infrastructure.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<FlashcardsContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("FlashcardsConnection")));

builder.Services.AddTransient<IFlashcardsRepo, FlashcardsRepo>();
builder.Services.AddTransient<IFlashcardsService, FlashcardsService>();

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

app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
