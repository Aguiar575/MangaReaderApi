using MangaReaderApi.Application.Utils;
using MangaReaderApi.Domain.Exceptions;
using Xunit;

namespace MangaReaderApi.Tests;

public class WebContentDownloaderTests
{
    private const string IMAGE_URL = "https://books.toscrape.com/media/cache/fe/72/fe72f0532301ec28892ae79a629a293c.jpg";
    private const string URL_WITHOUT_IMAGE = "https://blank.org";

    [Fact]
    public void ShouldReturnByteArray()
    {
        byte[] bytes = WebContentDownloader.GetImageBytes(IMAGE_URL).Result;
        Assert.NotEmpty(bytes);
    }

    [Fact]
    public void ShouldReturnEmptyByteArray()
    {
        byte[] bytes = WebContentDownloader.GetImageBytes(URL_WITHOUT_IMAGE).Result;
        Assert.Empty(bytes);
    }

    [Fact]
    public void ShouldThrowImageNotFoundException()
    {
        var ex = Assert.ThrowsAsync<ImageNotFoundException>(() => WebContentDownloader.GetImageBytes(""));
        Assert.IsType<ImageNotFoundException>(ex.Result);
    }
}
