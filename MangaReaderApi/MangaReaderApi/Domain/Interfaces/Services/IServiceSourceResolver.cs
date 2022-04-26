using MangaReaderApi.Domain.Dto;

namespace MangaReaderApi.Domain.Interfaces.Services;

public interface IServiceSourceResolver
{
    GetMangaRequestDto ResolveSource(string sourceName);
}
