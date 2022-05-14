using MangaReaderApi.Domain.Interfaces.Services.Domain.Factorie;
using Microsoft.AspNetCore.Mvc;

namespace MangaReaderApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GetMangaController : ControllerBase
{
    private readonly IChapterMangaDtoFactory _chapterMangaDtoFactory;

    public GetMangaController(IChapterMangaDtoFactory chapterMangaDtoFactory)
    {
        _chapterMangaDtoFactory = chapterMangaDtoFactory;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public bool Get()
    {
        return true;
    }
}

