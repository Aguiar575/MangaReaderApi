using MangaReaderApi.Domain.Dto;
using MangaReaderApi.Domain.Interfaces.Services.Domain;
using MangaReaderApi.Domain.Interfaces.utils;
using Newtonsoft.Json;

namespace MangaReaderApi.Domain.Services;

public class ServiceJasonReader : IServiceJasonReader
{
    private readonly IReader _reader;

    public ServiceJasonReader(IReader reader)
    {
        _reader = reader;
    }

    public IList<GetMangaRequestDto> LoadJson(string filePath)
    {
        try
        {
            using (StreamReader r = _reader.GetReader(filePath))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<GetMangaRequestDto>>(json)
                    ?? new List<GetMangaRequestDto>();
            }
        }
        catch
        {
            return new List<GetMangaRequestDto>();
        }
    }
}