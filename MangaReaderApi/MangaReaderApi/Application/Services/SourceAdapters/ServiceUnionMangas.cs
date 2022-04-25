using MangaReaderApi.Domain.Entities;
using MangaReaderApi.Domain.Interfaces.Services;

namespace MangaReaderApi.Application.Services.SourceAdapters;

public class ServiceUnionMangas : IServiceSourceCrawlerAdapter
{
    private readonly IServiceWebCrawler _serviceWebCrawler;

    public ServiceUnionMangas(IServiceWebCrawler serviceWebCrawler)
    {
        SourceName = "UnionMangas";
       _serviceWebCrawler = serviceWebCrawler;
    }

    private const string IMAGE_HTML_NODE = "//div/img";

    public string SourceName { get; private set; }

    public bool DownloadChapter(string ChapterUrl)
    {
        throw new NotImplementedException();
    }
}

