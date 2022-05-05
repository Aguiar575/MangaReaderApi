using MangaReaderApi.Domain.Exceptions;
using MangaReaderApi.Domain.Interfaces.Services.Domain;
using MangaReaderApi.Domain.ValueObjects;

namespace MangaReaderApi.Domain.Services;

public class ServiceSourceResolver : IServiceSourceResolver
{
    private readonly IServiceJasonReader _serviceJasonReader;
    private const string JSON_FILE_PATH = "Sources.Json";

    public ServiceSourceResolver(IServiceJasonReader serviceJasonReader)
    {
        _serviceJasonReader = serviceJasonReader;
    }

    public MangaSource ResolveSource(string sourceName) =>
        GetSources(JSON_FILE_PATH).Where(e => e.SourceName == sourceName).FirstOrDefault()
        ?? throw new SourceNotFoundException();

    private IList<MangaSource> GetSources(string jsonFilePath) =>
        _serviceJasonReader.LoadJson(jsonFilePath);

}

