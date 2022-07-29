using MangaReaderApi.Domain.ValueObjects;

namespace MangaReaderApi.Domain.Interfaces.Services;

public interface IServiceJasonReader
{
    IList<MangaSource> LoadJson(string filePath);
}

