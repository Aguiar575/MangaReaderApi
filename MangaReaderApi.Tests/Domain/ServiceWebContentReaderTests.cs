using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using MangaReaderApi.Domain.Exceptions;
using MangaReaderApi.Domain.Services;
using Moq;
using Xunit;

namespace MangaReaderApi.Tests.Domain;

public class ServiceWebContentReaderTests
{
    private const string IMAGE_URL = "https://books.toscrape.com/media/cache/fe/72/fe72f0532301ec28892ae79a629a293c.jpg";
    private const string URL_WITHOUT_IMAGE = "https://blank.org";

    [Fact]
    public void GetImageBytes_Should_Return_Byte_Array()
    {
        var httpClientFactory = new Mock<HttpClient>();
        var sut = new ServiceWebContentReader(httpClientFactory.Object);

        byte[] bytes = sut.GetImageBytes(IMAGE_URL).Result;
        Assert.NotEmpty(bytes);
    }

    [Fact]
    public void GetImageBytes_Should_Return_Empty_Byte_Array()
    {
        var httpClientFactory = new Mock<HttpClient>();
        var sut = new ServiceWebContentReader(httpClientFactory.Object);

        byte[] bytes = sut.GetImageBytes(URL_WITHOUT_IMAGE).Result;
        Assert.Empty(bytes);
    }

    [Fact]
    public void GetImageBytes_Should_Throw_ImageNotFoundException()
    {
        var httpClientFactory = new Mock<HttpClient>();
        var sut = new ServiceWebContentReader(httpClientFactory.Object);

        var ex = Assert.ThrowsAsync<ImageUrlNotFoundException>(() => sut.GetImageBytes(""));
        Assert.IsType<ImageUrlNotFoundException>(ex.Result);
    }

    [Fact]
    public void GetAllImageBytes_Should_Return_Byte_Array_List()
    {
        var httpClientFactory = new Mock<HttpClient>();
        var sut = new ServiceWebContentReader(httpClientFactory.Object);

        List<string> images = new List<string> { IMAGE_URL };
        IAsyncEnumerable<byte[]> bytes = sut.GetAllImageBytes(images);

        Assert.NotEmpty(bytes.ToEnumerable());
    }
}
