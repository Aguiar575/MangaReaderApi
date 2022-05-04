namespace MangaReaderApi.Domain.Interfaces.Services;

public interface IServiceWebCrawler
{
    IEnumerable<string> GetImagesFromUrl(string url, string imgHtmlNode);
}

