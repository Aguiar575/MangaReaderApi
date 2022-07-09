using System.Collections.Generic;
using MangaReaderApi.Domain.Services;
using Xunit;
using MangaReaderApi.Domain.ValueObjects;
using MangaReaderApi.Domain.Exceptions;
using MangaReaderApi.Tests.Fixture;

namespace MangaReaderApi.Tests.Domain;

public class ServiceWebCrawlerTests
{
    private const string SCRAPE_THIS = "https://books.toscrape.com/catalogue/a-light-in-the-attic_1000/index.html";

    [Fact]
    public void ShouldReturnOnlyOneImageSource()
    {
        MangaSource mangaSource = new MangaSource("MangaSource", "//div/img");
        var mangaRequestDto = ChapterDtoFixtureFactory.Create(SCRAPE_THIS, mangaSource);

        var sut = new ServiceWebCrawler();
        IEnumerable<string> imageSources = sut
            .GetImagesFromChapterRequest(mangaRequestDto);

        Assert.Single(imageSources);
    }

    [Fact]
    public void ShouldReturnImageNodeNotFoundException()
    {
        MangaSource mangaSource = new MangaSource("MangaSource", "");
        var mangaRequestDto = ChapterDtoFixtureFactory.Create(SCRAPE_THIS, mangaSource);

        var sut = new ServiceWebCrawler();
        var ex = Assert.Throws<ImageNodeNotFoundException>
            (() => sut.GetImagesFromChapterRequest(mangaRequestDto));

        Assert.IsType<ImageNodeNotFoundException>(ex);
    }
}
