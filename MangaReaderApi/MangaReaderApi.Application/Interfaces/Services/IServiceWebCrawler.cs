using MangaReaderApi.Domain.Entities;

namespace MangaReaderApi.Application.Interfaces.Services;

public interface IServiceWebCrawler
{
    CrawlerResult GetHtmlFromUrl(string url);
    ICollection<byte[]> GetImagesFromHtml(CrawlerResult content);
}

