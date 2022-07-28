namespace MangaReaderApi.Application.Interfaces.Services;

public interface IServicePdfConversor
{
    MemoryStream CreateChapterPdfWithBytes(IEnumerable<byte[]> ChapterImagesBytes);
}

