using System.Collections.Generic;
using MangaReaderApi.Application.Services;
using MangaReaderApi.Domain.Interfaces.Services;
using Xunit;

namespace MangaReaderApi.Tests;

public class ServiceWebCrawlerTest
{
    private readonly IServiceWebCrawler serviceWebCrawler;
    private const string SCRAPE_THIS = "https://books.toscrape.com/catalogue/a-light-in-the-attic_1000/index.html";
    private const string FIND_THIS_NODE = "//div//img";

    public ServiceWebCrawlerTest()
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
