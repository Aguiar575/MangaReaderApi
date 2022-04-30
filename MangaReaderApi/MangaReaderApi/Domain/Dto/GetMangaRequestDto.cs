namespace MangaReaderApi.Domain.Dto
{
	public class GetMangaRequestDto
	{
		public GetMangaRequestDto(string sourceName, string htmlImageNode)
		{
			SourceName = sourceName;
			HtmlImageNode = htmlImageNode;
		}

		public string SourceName { get; private set; }
		public string HtmlImageNode { get; private set; }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            GetMangaRequestDto other = (GetMangaRequestDto)obj;

            return SourceName.Equals(other.SourceName) && HtmlImageNode.Equals(other.HtmlImageNode);
        }

        public override int GetHashCode() => 
            new { SourceName, HtmlImageNode }.GetHashCode();

    }
}

