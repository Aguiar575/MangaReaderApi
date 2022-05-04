using System;

namespace MangaReaderApi.Domain.Interfaces.Services.Domain;

public interface IServiceWebContentReader
{
    Task<byte[]> GetImageBytes(string imageUrl);
}

