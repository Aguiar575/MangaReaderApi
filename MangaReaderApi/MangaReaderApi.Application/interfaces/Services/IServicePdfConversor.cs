
using MangaReaderApi.Domain.Enum;

namespace MangaReaderApi.Application.Interfaces.Services;

public interface IServicePdfConversor
{
    DeviceFileFormats deviceFormat { get; }
    MemoryStream CreateChapterPdfWithBytes(IEnumerable<byte[]> ChapterImagesBytes);
}

