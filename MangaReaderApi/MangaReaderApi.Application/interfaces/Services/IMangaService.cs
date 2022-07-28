using MangaReaderApi.Domain.Dto;

namespace MangaReaderApi.Application.Interfaces.Services;

public interface IMangaService
{
    byte[] GetPdfChapter(GetMangaChapterRequest request);
}

