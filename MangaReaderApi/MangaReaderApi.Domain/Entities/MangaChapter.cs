using MangaReaderApi.Domain.ValueObjects;

namespace MangaReaderApi.Domain.Entities;

public class MangaChapter
{
    public MangaChapter(string mangaName,
                        int chapterNumber,
                        bool isFinalChapter,
                        ChapterContent content)
    {
        MangaName = mangaName;
        ChapterNumber = chapterNumber;
        IsFinalChapter = isFinalChapter;
        Content = content;
    }

    public string MangaName { get; }
    public int ChapterNumber { get; }
    public bool IsFinalChapter { get; }
    public ChapterContent Content { get; }
}

