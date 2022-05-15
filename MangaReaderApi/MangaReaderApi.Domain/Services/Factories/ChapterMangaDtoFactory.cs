using MangaReaderApi.Domain.Dto;
using MangaReaderApi.Domain.Interfaces.Services.Domain;
using MangaReaderApi.Domain.Interfaces.Services.Domain.Factories;

namespace MangaReaderApi.Domain.Services.Factories;

public class ChapterMangaDtoFactory : IChapterMangaDtoFactory
{
    private readonly IServiceSourceResolver _serviceSourceResolver;

    public ChapterMangaDtoFactory(IServiceSourceResolver serviceSourceResolver)
    {
        _serviceSourceResolver = serviceSourceResolver;
    }

    public GetMangaChapterRequest Create(string chapterUrl, string source) =>
       new GetMangaChapterRequest(_serviceSourceResolver.ResolveSource(source),
           chapterUrl);
}