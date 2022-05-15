using MangaReaderApi.Domain.Dto;
using MangaReaderApi.Domain.Interfaces.Services.Application;
using MangaReaderApi.Domain.Interfaces.Services.Domain;

namespace MangaReaderApi.Application.Services;

public class ServiceChapter : IServiceChapter
{
    private readonly IServiceWebCrawler _serviceWebCrawler;
    private readonly IServiceWebContentReader _serviceWebContentReader;

    public ServiceChapter(IServiceWebCrawler serviceWebCrawler,
                          IServiceWebContentReader serviceWebContentReader)
    {
        _serviceWebCrawler = serviceWebCrawler;
        _serviceWebContentReader = serviceWebContentReader;
    }

    public IEnumerable<byte[]> GetChapterImageBytes(GetMangaChapterRequest request)
    {
        IEnumerable<string> chapterImagesUrl = _serviceWebCrawler
            .GetImagesFromChapterRequest(request);

        return _serviceWebContentReader.GetAllImageBytes(chapterImagesUrl);
    }
}

