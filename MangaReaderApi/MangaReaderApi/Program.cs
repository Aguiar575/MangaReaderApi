using System.Reflection;
using MangaReaderApi.Application.Services;
using MangaReaderApi.Application.Utils;
using MangaReaderApi.Domain.Interfaces.Services;
using MangaReaderApi.Domain.Interfaces.utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IServiceWebCrawler, ServiceWebCrawler>();
builder.Services.AddTransient<IServiceJasonReader, ServiceJasonReader>();
builder.Services.AddTransient<IReader, Reader>();
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

