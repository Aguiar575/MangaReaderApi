using MangaReaderApi.Domain.Dto;

namespace MangaReaderApi.Domain.Interfaces.Services.Application;

public interface IMangaService
{
    byte[] GetChapter(GetMangaChapterRequest request);
}

