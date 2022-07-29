using MangaReaderApi.Domain.ValueObjects;

namespace MangaReaderApi.Domain.Interfaces.Services;

public interface IServiceSourceResolver
{
    MangaSource ResolveSource(string sourceName);
}
