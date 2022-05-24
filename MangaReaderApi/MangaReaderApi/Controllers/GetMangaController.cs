using MangaReaderApi.Domain.Dto;
using MangaReaderApi.Domain.Interfaces.Facades.Application;
using MangaReaderApi.Domain.Interfaces.Services.Application;
using MangaReaderApi.Domain.Interfaces.Services.Domain.Factories;
using Microsoft.AspNetCore.Mvc;

namespace MangaReaderApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MangaController : ControllerBase
{
    private readonly IChapterContentExtractor _chapterContentExtractor;
    private readonly IChapterMangaDtoFactory _chapterMangaDtoFactory;
    private readonly IServicePdfConversor _servicePdfConversor;

    public MangaController(IChapterContentExtractor chapterContentExtractor,
                           IChapterMangaDtoFactory chapterMangaDtoFactory,
                           IServicePdfConversor servicePdfConversor)
    {
        _chapterContentExtractor = chapterContentExtractor;
        _chapterMangaDtoFactory = chapterMangaDtoFactory;
        _servicePdfConversor = servicePdfConversor;
    }

    [HttpPost(Name = "GetMangaChapter")]
    public FileResult Post(string source, string chapterUrl)
    {
        GetMangaChapterRequest request = _chapterMangaDtoFactory.Create(chapterUrl, source);
        IEnumerable<byte[]> chapterContent = _chapterContentExtractor.GetChapterImageBytes(request);

        using (var chapterFile = _servicePdfConversor.CreateChapterPdfWithBytes(chapterContent))
        {
            return File(chapterFile.ToArray(), "application/pdf", "chapter.pdf");
        }
    }
}

