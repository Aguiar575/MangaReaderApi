using MangaReaderApi.Domain.Dto;

namespace MangaReaderApi.Domain.Interfaces.Services.Domain.Factories;

public interface IChapterMangaDtoFactory
{
    public GetMangaChapterRequest Create(string chapterUrl, string source);
}

