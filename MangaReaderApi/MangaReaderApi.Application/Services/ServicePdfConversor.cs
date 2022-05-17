using MangaReaderApi.Domain.Interfaces.Services.Application;

namespace MangaReaderApi.Application.Services;

public class ServicePdfConversor : IServicePdfConversor
{
    public bool CreateChapterPdf(IEnumerable<byte[]> ChapterImagesBytes)
    {
        throw new NotImplementedException();
    }
}

