namespace MangaReaderApi.Domain.Interfaces.Services.Application;

public interface IServicePdfConversor
{
    MemoryStream CreateChapterPdf(IEnumerable<byte[]> ChapterImagesBytes);
}

