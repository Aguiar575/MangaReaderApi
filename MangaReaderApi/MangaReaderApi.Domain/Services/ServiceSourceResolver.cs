using MangaReaderApi.Domain.Dto;
using MangaReaderApi.Domain.Exceptions;
using MangaReaderApi.Domain.Interfaces.Services.Domain;

namespace MangaReaderApi.Domain.Services;

public class ServiceSourceResolver : IServiceSourceResolver
{
    private readonly IServiceJasonReader _serviceJasonReader;
    private const string JSON_FILE_PATH = "Sources.Json";

    public ServiceSourceResolver(IServiceJasonReader serviceJasonReader)
    {
        _serviceJasonReader = serviceJasonReader;
    }

    public GetMangaRequestDto ResolveSource(string sourceName) =>
        GetSources(JSON_FILE_PATH).Where(e => e.SourceName == sourceName).FirstOrDefault()
        ?? throw new SourceNotFoundException();

    private IList<GetMangaRequestDto> GetSources(string jsonFilePath) =>
        _serviceJasonReader.LoadJson(jsonFilePath);

}

