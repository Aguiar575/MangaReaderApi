namespace MangaReaderApi.Domain.Interfaces.Services;

public interface IServiceWebContentReader
{
    IAsyncEnumerable<byte[]> GetAllImageBytes(IEnumerable<string> images);
    Task<byte[]> GetImageBytes(string imageUrl);
}
