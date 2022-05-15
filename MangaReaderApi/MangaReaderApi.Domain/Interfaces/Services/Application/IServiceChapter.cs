using MangaReaderApi.Domain.Dto;

namespace MangaReaderApi.Domain.Interfaces.Services.Application;

public interface IServiceChapter
{
    IEnumerable<byte[]> GetChapterImageBytes(GetMangaChapterRequest request);
}

