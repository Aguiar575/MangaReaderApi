using System.Collections.Generic;
using MangaReaderApi.Domain.Services;
using Xunit;
using MangaReaderApi.Domain.Interfaces.Services.Domain;
using MangaReaderApi.Domain.Dto;
using MangaReaderApi.Domain.ValueObjects;

namespace MangaReaderApi.Tests.Domain;

public class ServiceWebCrawlerTests
{
    private readonly IServiceWebCrawler serviceWebCrawler;
    private const string SCRAPE_THIS = "https://books.toscrape.com/catalogue/a-light-in-the-attic_1000/index.html";
    private const string FIND_THIS_NODE = "//div//img";
    private GetMangaChapterRequest MangaRequest;

    public ServiceWebCrawlerTests()
    {
        MangaSource source = new MangaSource("MangaSource", FIND_THIS_NODE);
        MangaRequest = new GetMangaChapterRequest(source, SCRAPE_THIS);
        serviceWebCrawler = new ServiceWebCrawler();
    }

    [Fact]
    public void ShouldReturnOnlyOneImageSource()
    {
        IEnumerable<string> imageSources = serviceWebCrawler
            .GetImagesFromChapterRequest(MangaRequest);
        Assert.Single(imageSources);
    }
}
