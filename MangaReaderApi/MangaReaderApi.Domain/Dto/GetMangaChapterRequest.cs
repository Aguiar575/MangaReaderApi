using MangaReaderApi.Domain.ValueObjects;

namespace MangaReaderApi.Domain.Dto;

public class GetMangaChapterRequest : DtoClass
{
    public GetMangaChapterRequest(MangaSource source, string chapterUrl)
    {
        Source = source;
        ChapterUrl = chapterUrl;
    }

    public MangaSource Source { get; private set; }
    public string ChapterUrl { get; private set; }
}

