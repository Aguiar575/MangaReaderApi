using MangaReaderApi.Domain.Exceptions;
using MangaReaderApi.Domain.Interfaces.Services;
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

            byte[] bytesOfResponse = await response.Content.ReadAsByteArrayAsync();

            if (response.IsSuccessStatusCode && bytesOfResponse.IsImage())
                return bytesOfResponse;
        }
        catch
        {
            throw new ImageUrlNotFoundException();
        }

        return new byte[] { };
    }

    public async IAsyncEnumerable<byte[]> GetAllImageBytes(IEnumerable<string> images)
    {
        foreach (var image in images)
        {
            byte[] bytesOfImage = await GetImageBytes(image);
            yield return bytesOfImage;
        }
    }
}
