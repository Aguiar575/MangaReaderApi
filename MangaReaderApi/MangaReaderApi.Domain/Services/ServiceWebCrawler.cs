using MangaReaderApi.Domain.Interfaces.Services.Domain;
using HtmlAgilityPack;
using MangaReaderApi.Domain.Dto;

namespace MangaReaderApi.Domain.Services;

public class ServiceWebCrawler : IServiceWebCrawler
{
    public IEnumerable<string> GetImagesFromChapterRequest(GetMangaChapterRequest chapterRequest)
    {
        HtmlDocument html = GetHtmlFromUrl(chapterRequest.ChapterUrl);
        return ExtractImagesFromUrl(html, chapterRequest.Source.HtmlImageNode);
    }

    private HtmlDocument GetHtmlFromUrl(string url)
    {
        HtmlWeb web = new HtmlWeb();
        HtmlDocument htmlDocument = web.Load(url);
        return htmlDocument;
    }

    private IEnumerable<string> ExtractImagesFromUrl(HtmlDocument html, string imgNode)
    {
        HtmlNodeCollection linkNodes = html.DocumentNode.SelectNodes(imgNode);
        return linkNodes.Select(node => node.Attributes["src"].Value);
    }

}

