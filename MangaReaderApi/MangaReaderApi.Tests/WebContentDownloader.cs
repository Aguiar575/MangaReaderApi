using MangaReaderApi.Application.Utils;
using Xunit;

namespace MangaReaderApi.Tests;

public class WebContentDownloaderTest
{
    private const string IMAGE_URL = "https://books.toscrape.com/media/cache/fe/72/fe72f0532301ec28892ae79a629a293c.jpg";

    [Fact]
    public void ShouldReturnByteArray()
    {
        byte[] bytes = WebContentDownloader.GetImageBytes(IMAGE_URL).Result;
        Assert.NotEmpty(bytes);
    }

    [Fact]
    public void ShouldReturnEmptyByteArray()
    {
        byte[] bytes = WebContentDownloader.GetImageBytes("").Result;
        Assert.Empty(bytes);
    }
}
