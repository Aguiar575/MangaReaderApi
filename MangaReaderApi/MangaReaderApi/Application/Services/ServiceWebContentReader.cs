using MangaReaderApi.Domain.Exceptions;
using MangaReaderApi.Domain.Interfaces.Services;

namespace MangaReaderApi.Application.Utils;

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
                && ImageTools.IsImage(response.Content.ReadAsByteArrayAsync().Result))
                return response.Content.ReadAsByteArrayAsync().Result;
        }
        catch
        {
            throw new ImageNotFoundException();
        }

        return new byte[] { };
    }
}

