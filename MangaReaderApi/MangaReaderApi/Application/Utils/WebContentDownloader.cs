using MangaReaderApi.Domain.Exceptions;

namespace MangaReaderApi.Application.Utils;

public static class WebContentDownloader
{
    public static async Task<byte[]> GetImageBytes(string imageUrl)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(imageUrl);
                if (response.IsSuccessStatusCode
                    && ImageTools.IsImage(response.Content.ReadAsByteArrayAsync().Result))
                    return response.Content.ReadAsByteArrayAsync().Result;
            }
        }
        catch
        {
            throw new ImageNotFoundException();
        }

        return new byte[] { };
    }
}

