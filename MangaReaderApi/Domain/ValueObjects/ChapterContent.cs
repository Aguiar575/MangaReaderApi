namespace MangaReaderApi.Domain.ValueObjects;

public class ChapterContent
{
    public ChapterContent()
    {
        Content = new HashSet<byte[]>();
    }

    public ICollection<byte[]> Content { get; }

    public void AddContent(byte[] content) =>
        Content.Add(content);
}

