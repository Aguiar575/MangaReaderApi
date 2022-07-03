using MangaReaderApi.Domain.Dto;
using MangaReaderApi.Domain.Interfaces.Services.Application;
using MangaReaderApi.Domain.Interfaces.Services.Domain.Factories;
using Microsoft.AspNetCore.Mvc;

namespace MangaReaderApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MangaController : ControllerBase
{
    private readonly IChapterMangaDtoFactory _chapterMangaDtoFactory;
    private readonly IMangaService _mangaService;

    public MangaController(IChapterMangaDtoFactory chapterMangaDtoFactory,
                           IMangaService mangaService)
    {
        _chapterMangaDtoFactory = chapterMangaDtoFactory;
        _mangaService = mangaService;
    }

    [HttpPost(Name = "GetMangaChapter")]
    public FileResult Post(string source, string chapterUrl)
    {
        GetMangaChapterRequest request = _chapterMangaDtoFactory.Create(chapterUrl, source);
        var chapterFile = _mangaService.GetChapter(request);

        return File(chapterFile, "application/pdf", "chapter.pdf");
    }
}

