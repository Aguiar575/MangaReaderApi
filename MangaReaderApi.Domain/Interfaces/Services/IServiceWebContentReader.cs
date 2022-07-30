namespace MangaReaderApi.Domain.Interfaces.Services;

public interface IServiceWebContentReader
{
    IEnumerable<byte[]> GetAllImageBytes(IEnumerable<string> images);
    Task<byte[]> GetImageBytes(string imageUrl);
}
