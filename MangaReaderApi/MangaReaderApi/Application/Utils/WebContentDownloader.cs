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
                if (response.IsSuccessStatusCode)
                    return response.Content.ReadAsByteArrayAsync().Result;
            }
        }
        catch
        {
          //TODO
          //Logs Here
          //Maybe ex...
        }

        return new byte[] { };
    }
}

