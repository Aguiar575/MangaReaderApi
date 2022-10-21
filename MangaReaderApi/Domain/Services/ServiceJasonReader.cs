using MangaReaderApi.Domain.Interfaces.Services;
using MangaReaderApi.Domain.Interfaces.utils;
using MangaReaderApi.Domain.ValueObjects;
using Newtonsoft.Json;

namespace MangaReaderApi.Domain.Services;

public class ServiceJasonReader : IServiceJasonReader
{
    private readonly IReader _reader;

    public ServiceJasonReader(IReader reader)
    {
        _reader = reader;
    }

    public IList<MangaSource> LoadJson(string filePath)
    {
        try
        {
            using (StreamReader r = _reader.GetReader(filePath))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<MangaSource>>(json)
                    ?? new List<MangaSource>();
            }
        }
        catch
        {
            return new List<MangaSource>();
        }
    }
}