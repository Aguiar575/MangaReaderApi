using MangaReaderApi.Domain.ValueObjects;

namespace MangaReaderApi.Domain.Interfaces.Services.Domain;

public interface IServiceSourceResolver
{
    MangaSource ResolveSource(string sourceName);
}
