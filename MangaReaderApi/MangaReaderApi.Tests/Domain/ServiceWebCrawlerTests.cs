using System.Collections.Generic;
using MangaReaderApi.Domain.Services;
using Xunit;
using MangaReaderApi.Domain.ValueObjects;
using MangaReaderApi.Domain.Exceptions;
using Moq;
using MangaReaderApi.Domain.Interfaces.Services.Domain;
using MangaReaderApi.Domain.Services.Factories;

namespace MangaReaderApi.Tests.Domain;

public class ServiceWebCrawlerTests
{
    private const string SCRAPE_THIS = "https://books.toscrape.com/catalogue/a-light-in-the-attic_1000/index.html";


    [Fact]
    public void ShouldReturnOnlyOneImageSource()
    {
        MangaSource mangaSource = new MangaSource("MangaSource", "//div/img");
        var serviceSourceResolver = new Mock<IServiceSourceResolver>();
        serviceSourceResolver.Setup(sr => sr.ResolveSource(It.IsAny<string>()))
            .Returns(mangaSource);
        var chapterMangaDtoFactory = new ChapterMangaDtoFactory(serviceSourceResolver.Object);
        var mangaRequestDto = chapterMangaDtoFactory.Create(SCRAPE_THIS, "MangaSource");

        var serviceWebCrawler = new ServiceWebCrawler();
        IEnumerable<string> imageSources = serviceWebCrawler
            .GetImagesFromChapterRequest(mangaRequestDto);

        Assert.Single(imageSources);
    }

    [Fact]
    public void ShouldReturnImageNodeNotFoundException()
    {
        MangaSource mangaSource = new MangaSource("MangaSource", "");
        var serviceSourceResolver = new Mock<IServiceSourceResolver>();
        serviceSourceResolver.Setup(sr => sr.ResolveSource(It.IsAny<string>()))
            .Returns(mangaSource);
        var chapterMangaDtoFactory = new ChapterMangaDtoFactory(serviceSourceResolver.Object);
        var mangaRequestDto = chapterMangaDtoFactory.Create(SCRAPE_THIS, "MangaSource");

        var serviceWebCrawler = new ServiceWebCrawler();
        var ex = Assert.Throws<ImageNodeNotFoundException>
            (() => serviceWebCrawler.GetImagesFromChapterRequest(mangaRequestDto));

        Assert.IsType<ImageNodeNotFoundException>(ex);
    }
}
