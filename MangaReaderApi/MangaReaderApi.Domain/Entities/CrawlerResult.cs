namespace MangaReaderApi.Domain.Entities;

public class CrawlerResult
{
    public CrawlerResult(string UrlOrigin, string HtmlFromUrl)
    {
        this.UrlOrigin = UrlOrigin;
        this.HtmlFromUrl = HtmlFromUrl;
    }

    public string UrlOrigin { get; set; }
    public string HtmlFromUrl { get; set; }
}
