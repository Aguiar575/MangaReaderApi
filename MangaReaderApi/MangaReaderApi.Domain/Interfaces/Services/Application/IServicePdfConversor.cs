namespace MangaReaderApi.Domain.Interfaces.Services.Application;

public interface IServicePdfConversor
{
    MemoryStream CreateChapterPdfWithBytes(IEnumerable<byte[]> ChapterImagesBytes);
}

