using Microsoft.AspNetCore.Mvc;

namespace MangaReaderApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GetMangaController : ControllerBase
{
    [HttpGet(Name = "GetWeatherForecast")]
    public bool Get()
    {
        return true;
    }
}

