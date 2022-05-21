using Microsoft.AspNetCore.Mvc;

namespace MangaReaderApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MangaController : ControllerBase
{
    [HttpGet(Name = "GetMangaChapter")]
    public bool Get()
    {
        return true;
    }
}

