using MangaReaderApi.Domain.Dto;
using MangaReaderApi.Domain.Interfaces.Services;
using MangaReaderApi.Domain.Services.Factories;
using MangaReaderApi.Domain.ValueObjects;
using MangaReaderApi.Tests.TestHelpers;
using Moq;

namespace MangaReaderApi.Tests.Fixture;

public class ChapterDtoFixtureFactory : AssemblyLocationHelper
{
    public static GetMangaChapterRequest Create(string urlToScrape, MangaSource mangaSource)
    {
        var serviceSourceResolver = new Mock<IServiceSourceResolver>();
        serviceSourceResolver.Setup(sr => sr.ResolveSource(It.IsAny<string>()))
            .Returns(mangaSource);

        var chapterMangaDtoFactory = new ChapterMangaDtoFactory(serviceSourceResolver.Object);
        return chapterMangaDtoFactory.Create(urlToScrape, "MangaSource");
    }
}

