using System.Reflection;
using MangaReaderApi.Application.Services;
using MangaReaderApi.Domain.Interfaces.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IServiceWebCrawler, ServiceWebCrawler>();

foreach(var t in Assembly.GetExecutingAssembly()
                         .GetTypes()
                         .Where(mytype => mytype.GetInterfaces()
                         .Contains(typeof(IServiceSourceCrawlerAdapter))))
{
    builder.Services.AddTransient(typeof(IServiceSourceCrawlerAdapter), t);
}

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

