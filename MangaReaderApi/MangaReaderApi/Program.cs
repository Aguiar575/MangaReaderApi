using MangaReaderApi.Application.Services;
using MangaReaderApi.Domain.Interfaces.Facades.Application;
using MangaReaderApi.Domain.Interfaces.Services.Application;
using MangaReaderApi.Domain.Interfaces.Services.Domain;
using MangaReaderApi.Domain.Interfaces.Services.Domain.Factories;
using MangaReaderApi.Domain.Interfaces.utils;
using MangaReaderApi.Domain.Services;
using MangaReaderApi.Domain.Services.Factories;
using MangaReaderApi.Domain.utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddTransient<IReader, Reader>();
builder.Services.AddTransient<IServiceWebCrawler, ServiceWebCrawler>();
builder.Services.AddTransient<IServiceJasonReader, ServiceJasonReader>();
builder.Services.AddTransient<IServiceSourceResolver, ServiceSourceResolver>();
builder.Services.AddTransient<IChapterMangaDtoFactory, ChapterMangaDtoFactory>();
builder.Services.AddTransient<IServicePdfConversor, ServiceKindlePdfConversor>();
builder.Services.AddTransient<IMangaService, MangaService>();

builder.Services.AddHttpClient<IServiceWebContentReader, ServiceWebContentReader>();
builder.Services.AddSingleton<IChapterContentExtractor, ChapterContentExtractor>();

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

