using MangaReaderApi.Domain.Dto;
using MangaReaderApi.Domain.Enum;

namespace MangaReaderApi.Application.Interfaces.Services;

public interface IMangaService
{
    byte[] GetPdfChapter(GetMangaChapterRequest request, DeviceFileFormats format);
}

