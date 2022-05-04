using MangaReaderApi.Domain.Dto;

namespace MangaReaderApi.Domain.Interfaces.Services.Domain;

public interface IServiceSourceResolver
{
    GetMangaRequestDto ResolveSource(string sourceName);
}
