using MangaReaderApi.Domain.ValueObjects;

namespace MangaReaderApi.Domain.Interfaces.Services.Domain;

public interface IServiceJasonReader
{
    IList<MangaSource> LoadJson(string filePath);
}

