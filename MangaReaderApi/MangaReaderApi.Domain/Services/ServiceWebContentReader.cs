using MangaReaderApi.Domain.Exceptions;
using MangaReaderApi.Domain.Interfaces.Services.Domain;
using MangaReaderApi.Domain.utils;

namespace MangaReaderApi.Domain.Services;

public class ServiceWebContentReader : IServiceWebContentReader
{
    private readonly HttpClient _httpClient;

    public ServiceWebContentReader(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<byte[]> GetImageBytes(string imageUrl)
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(imageUrl);
            if (response.IsSuccessStatusCode
                && response.Content.ReadAsByteArrayAsync().Result.IsImage())
                return response.Content.ReadAsByteArrayAsync().Result;
        }
        catch
        {
            throw new ImageUrlNotFoundException();
        }

        return new byte[] { };
    }
}
