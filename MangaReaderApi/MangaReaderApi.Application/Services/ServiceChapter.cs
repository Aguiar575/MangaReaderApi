using MangaReaderApi.Domain.Dto;
using MangaReaderApi.Domain.Interfaces.Services.Application;
using MangaReaderApi.Domain.Interfaces.Services.Domain;

namespace MangaReaderApi.Application.Services;

public class ServiceChapter : IServiceChapter
{
    private readonly IServiceWebCrawler _serviceWebCrawler;

    public ServiceChapter(IServiceWebCrawler serviceWebCrawler)
    {
        _serviceWebCrawler = serviceWebCrawler;
    }

    public bool GetChapter(GetMangaChapterRequest request)
    {
        IEnumerable<string> chapterImagesUrl = _serviceWebCrawler
            .GetImagesFromChapterRequest(request);

        return true;
    }
}

