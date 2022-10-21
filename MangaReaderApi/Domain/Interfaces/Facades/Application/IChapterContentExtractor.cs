using MangaReaderApi.Domain.Dto;

namespace MangaReaderApi.Domain.Interfaces.Facades.Application;

public interface IChapterContentExtractor
{
    IAsyncEnumerable<byte[]> GetChapterImageBytes(GetMangaChapterRequest request);
}

