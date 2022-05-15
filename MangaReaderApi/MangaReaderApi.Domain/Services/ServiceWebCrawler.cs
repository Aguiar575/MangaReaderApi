using MangaReaderApi.Domain.Interfaces.Services.Domain;
using HtmlAgilityPack;
using MangaReaderApi.Domain.Dto;
using MangaReaderApi.Domain.Exceptions;

namespace MangaReaderApi.Domain.Services;

public class ServiceWebCrawler : IServiceWebCrawler
{
    public IEnumerable<string> GetImagesFromChapterRequest(GetMangaChapterRequest chapterRequest)
    {
        HtmlDocument html = GetHtmlFromUrl(chapterRequest.ChapterUrl);
        return ExtractImagesFromUrl(html, chapterRequest.Source.HtmlImageNode);
    }

    private static HtmlDocument GetHtmlFromUrl(string url)
    {
        HtmlWeb web = new HtmlWeb();
        HtmlDocument htmlDocument = web.Load(url);
        return htmlDocument;
    }

    private IEnumerable<string> ExtractImagesFromUrl(HtmlDocument html, string imgNode)
    {
        try
        {
            HtmlNodeCollection linkNodes = html.DocumentNode.SelectNodes(imgNode);
            var imageSource = linkNodes.Select(node => node.Attributes["src"].Value);
            return imageSource;
        }
        catch(Exception)
        {
            throw new ImageNodeNotFoundException();
        }
    }
}

