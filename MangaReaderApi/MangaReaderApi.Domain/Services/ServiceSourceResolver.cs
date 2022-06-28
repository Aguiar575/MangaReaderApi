using MangaReaderApi.Domain.Exceptions;
using MangaReaderApi.Domain.Interfaces.Services.Domain;
using MangaReaderApi.Domain.ValueObjects;

namespace MangaReaderApi.Domain.Services;

public class ServiceSourceResolver : IServiceSourceResolver
{
    private readonly IServiceJasonReader _serviceJasonReader;

    string JSON_FILE_PATH = Environment.CurrentDirectory + "/Sources.json";

    public ServiceSourceResolver(IServiceJasonReader serviceJasonReader)
    {
        _serviceJasonReader = serviceJasonReader;
    }

    public MangaSource ResolveSource(string sourceName)
    {
        return GetSources(JSON_FILE_PATH).Where(e => e.SourceName == sourceName).FirstOrDefault()
            ?? throw new SourceNotFoundException();

        IList<MangaSource> GetSources(string jsonFilePath) =>
            _serviceJasonReader.LoadJson(jsonFilePath);
    }

}

