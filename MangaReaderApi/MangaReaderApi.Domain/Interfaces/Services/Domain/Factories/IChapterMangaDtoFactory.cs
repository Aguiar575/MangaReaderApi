using MangaReaderApi.Domain.Dto;

namespace MangaReaderApi.Domain.Interfaces.Services.Domain.Factorie;

public interface IChapterMangaDtoFactory
{
    public GetMangaChapterRequest Create(string chapterUrl, string source);
}

