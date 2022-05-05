using MangaReaderApi.Domain.Dto;

namespace MangaReaderApi.Domain.Interfaces.Services.Domain;

public interface IServiceWebCrawler
{
    IEnumerable<string> GetImagesFromChapterRequest(GetMangaChapterRequest chapterRequest);
}

