namespace MangaReaderApi.Domain.ValueObjects;

public class MangaSource
{
    public MangaSource(string sourceName, string htmlImageNode)
    {
        SourceName = sourceName;
        HtmlImageNode = htmlImageNode;
    }

    public string SourceName { get; set; }
    public string HtmlImageNode { get; set; }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;

        MangaSource other = (MangaSource)obj;

        return SourceName.Equals(other.SourceName) && HtmlImageNode.Equals(other.HtmlImageNode);
    }

    public override int GetHashCode() =>
        new { SourceName, HtmlImageNode }.GetHashCode();

}

