using MangaReaderApi.Domain.Entities;

namespace MangaReaderApi.Domain.Interfaces.Services;

public interface IServiceChapter
{
    IEnumerable<byte[]> GetChapterContent();
    Chapter GetChapter(string chapterUrl, string imgHtmlNode);
}
