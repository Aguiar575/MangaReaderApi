using System.Collections.Generic;
using MangaReaderApi.Domain.Services;
using Xunit;
using MangaReaderApi.Domain.Interfaces.Services.Domain;

namespace MangaReaderApi.Tests.Domain;

public class ServiceWebCrawlerTests
{
    private readonly IServiceWebCrawler serviceWebCrawler;
    private const string SCRAPE_THIS = "https://books.toscrape.com/catalogue/a-light-in-the-attic_1000/index.html";
    private const string FIND_THIS_NODE = "//div//img";

    public ServiceWebCrawlerTests()
    {
        serviceWebCrawler = new ServiceWebCrawler();
    }

    [Fact]
    public void ShouldReturnOnlyOneImageSource()
    {
        IEnumerable<string> imageSources = serviceWebCrawler.GetImagesFromUrl(SCRAPE_THIS, FIND_THIS_NODE);
        Assert.Single(imageSources);
    }
}
