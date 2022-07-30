
using MangaReaderApi.Domain.Enum;

namespace MangaReaderApi.Application.Interfaces.Services;

public interface IPdfConversorServiceStrategy
{
    MemoryStream CreateChapterPdfWithBytes(IEnumerable<byte[]> chapterImagesBytes, DeviceFileFormats format);
}


