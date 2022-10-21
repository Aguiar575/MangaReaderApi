
using MangaReaderApi.Domain.Enum;

namespace MangaReaderApi.Application.Interfaces.Services;

public interface IPdfConversorServiceStrategy
{
    Task<MemoryStream> CreateChapterPdfWithBytesAsync(IAsyncEnumerable<byte[]> chapterImagesBytes, DeviceFileFormats format);
}


