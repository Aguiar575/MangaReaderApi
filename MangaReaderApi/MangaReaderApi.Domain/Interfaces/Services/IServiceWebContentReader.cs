using System;
namespace MangaReaderApi.Domain.Interfaces.Services;

public interface IServiceWebContentReader
{
    Task<byte[]> GetImageBytes(string imageUrl);
}

