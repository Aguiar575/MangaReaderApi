using System.Collections.Generic;
using System.Net.Http;
using MangaReaderApi.Domain.Exceptions;
using MangaReaderApi.Domain.Interfaces.Services.Domain;
using MangaReaderApi.Domain.Services;
using Moq;
using Xunit;

namespace MangaReaderApi.Tests.Domain;

public class ServiceWebContentReaderTests
{
    private const string IMAGE_URL = "https://books.toscrape.com/media/cache/fe/72/fe72f0532301ec28892ae79a629a293c.jpg";
    private const string URL_WITHOUT_IMAGE = "https://blank.org";
    private readonly IServiceWebContentReader sut;

    public ServiceWebContentReaderTests()
    {
        var httpClientFactory = new Mock<HttpClient>();
        sut = new ServiceWebContentReader(httpClientFactory.Object);
    }

    [Fact]
    public void ShouldReturnByteArray()
    {
        byte[] bytes = sut.GetImageBytes(IMAGE_URL).Result;
        Assert.NotEmpty(bytes);
    }

    [Fact]
    public void ShouldReturnEmptyByteArray()
    {
        byte[] bytes = sut.GetImageBytes(URL_WITHOUT_IMAGE).Result;
        Assert.Empty(bytes);
    }

    [Fact]
    public void ShouldThrowImageNotFoundException()
    {
        var ex = Assert.ThrowsAsync<ImageUrlNotFoundException>(() => sut.GetImageBytes(""));
        Assert.IsType<ImageUrlNotFoundException>(ex.Result);
    }

    [Fact]
    public void ShouldReturnByteArrayList()
    {
        List<string> images = new List<string> { IMAGE_URL };
        IEnumerable<byte[]> bytes = sut.GetAllImageBytes(images);

        Assert.NotEmpty(bytes);
    }
}
