namespace MangaReaderApi.Domain.Interfaces.Services.Domain;

public interface IServiceWebCrawler
{
    IEnumerable<string> GetImagesFromUrl(string url, string imgHtmlNode);
}

