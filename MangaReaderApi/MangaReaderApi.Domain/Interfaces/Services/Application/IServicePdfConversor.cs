namespace MangaReaderApi.Domain.Interfaces.Services.Application;

public interface IServicePdfConversor
{
    bool CreateChapterPdf(IEnumerable<byte[]> ChapterImagesBytes);
}

