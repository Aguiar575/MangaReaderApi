using MangaReaderApi.Domain.Interfaces.Services;
using HtmlAgilityPack;

namespace MangaReaderApi.Application.Services;

public class ServiceWebCrawler : IServiceWebCrawler
{

    public IEnumerable<string> GetSourceImagesFromUrl(string url, string imgHtmlNode)
    {
        HtmlDocument html = GetHtmlFromUrl(url);
        return ExtractImagesFromUrl(html, imgHtmlNode);
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

