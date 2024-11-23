using Microsoft.EntityFrameworkCore;
using MovieManager.Domain;
using MovieManager.Infrastructure.Interfaces;
using MovieManager.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MovieManagerDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MovieManagerStrConnection")));
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

// Add services to the container.

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
