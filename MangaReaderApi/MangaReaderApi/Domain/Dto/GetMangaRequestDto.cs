namespace MangaReaderApi.Domain.Dto
{
	public class GetMangaRequestDto
	{
		public GetMangaRequestDto(string htmlImageNode, string sourceName)
		{
			HtmlImageNode = htmlImageNode;
			SourceName = sourceName;
		}

		public string SourceName { get; private set; }
		public string HtmlImageNode { get; private set; }
	}
}

