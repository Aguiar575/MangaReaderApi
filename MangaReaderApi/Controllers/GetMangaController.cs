using MangaReaderApi.Application.Interfaces.Services;
using MangaReaderApi.Domain.Dto;
using MangaReaderApi.Domain.Enum;
using MangaReaderApi.Domain.Interfaces.Services;
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

    [HttpPost(Name = "GetMangaChapterKindle")]
    public async Task<FileResult> PostAsync(string source, string chapterUrl)
    {
        GetMangaChapterRequest request = _chapterMangaDtoFactory.Create(chapterUrl, source);
        byte[] chapterFile = await _mangaService.GetPdfChapterAsync(request, DeviceFileFormats.Kindle);

        return File(chapterFile, "application/pdf", "chapter.pdf");
    }
}

