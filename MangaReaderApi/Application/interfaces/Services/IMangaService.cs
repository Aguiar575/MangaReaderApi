using MangaReaderApi.Domain.Dto;
using MangaReaderApi.Domain.Enum;

namespace MangaReaderApi.Application.Interfaces.Services;

public interface IMangaService
{
    Task<byte[]> GetPdfChapterAsync(GetMangaChapterRequest request, DeviceFileFormats format);
}

