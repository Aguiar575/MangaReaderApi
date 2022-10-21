
using MangaReaderApi.Domain.Enum;

namespace MangaReaderApi.Application.Interfaces.Services;

public interface IServicePdfConversor
{
    DeviceFileFormats deviceFormat { get; }
    Task<MemoryStream> CreateChapterPdfWithBytesAsync(IAsyncEnumerable<byte[]> ChapterImagesBytes);
}

