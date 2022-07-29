using MangaReaderApi.Domain.Dto;

namespace MangaReaderApi.Domain.Interfaces.Services;

public interface IServiceWebCrawler
{
    IEnumerable<string> GetImagesFromChapterRequest(GetMangaChapterRequest chapterRequest);
}

