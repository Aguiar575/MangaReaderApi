using MangaReaderApi.Domain.Interfaces.Services.Domain;
using MangaReaderApi.Domain.Interfaces.utils;
using MangaReaderApi.Domain.Services;
using MangaReaderApi.Domain.utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IReader, Reader>();
builder.Services.AddTransient<IServiceWebCrawler, ServiceWebCrawler>();
builder.Services.AddTransient<IServiceJasonReader, ServiceJasonReader>();
builder.Services.AddHttpClient<IServiceWebContentReader, ServiceWebContentReader>();
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

