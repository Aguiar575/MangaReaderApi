namespace MangaReaderApi.Domain.Interfaces.Services;

public interface IServiceSourceCrawlerAdapter
{
    string SourceName { get; }

    bool DownloadChapter(string ChapterUrl);
}
