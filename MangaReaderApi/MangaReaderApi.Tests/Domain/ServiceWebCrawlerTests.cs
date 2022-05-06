using System.Collections.Generic;
using MangaReaderApi.Domain.Services;
using Xunit;
using MangaReaderApi.Domain.Dto;
using MangaReaderApi.Domain.ValueObjects;
using MangaReaderApi.Domain.Exceptions;

namespace MangaReaderApi.Tests.Domain;

public class ServiceWebCrawlerTests
{
    private const string SCRAPE_THIS = "https://books.toscrape.com/catalogue/a-light-in-the-attic_1000/index.html";

    [Fact]
    public void ShouldReturnOnlyOneImageSource()
    {
        var source = new MangaSource("MangaSource", "//div/img");
        var mangaRequest = new GetMangaChapterRequest(source, SCRAPE_THIS);
        var serviceWebCrawler = new ServiceWebCrawler();


        IEnumerable<string> imageSources = serviceWebCrawler
            .GetImagesFromChapterRequest(mangaRequest);
        Assert.Single(imageSources);
    }

    [Fact]
    public void ShouldReturnImageNodeNotFoundException()
    {
        var source = new MangaSource("MangaSource", "");
        var mangaRequest = new GetMangaChapterRequest(source, SCRAPE_THIS);
        var serviceWebCrawler = new ServiceWebCrawler();


        var ex = Assert.Throws<ImageNodeNotFoundException>
            (() => serviceWebCrawler.GetImagesFromChapterRequest(mangaRequest));

        Assert.IsType<ImageNodeNotFoundException>(ex);
    }
}
