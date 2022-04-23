namespace MangaReaderApi.Domain.Interfaces.Services;

public interface IServiceWebCrawler
{
    IEnumerable<string> GetSourceImagesFromUrl(string url, string imgHtmlNode);
}

