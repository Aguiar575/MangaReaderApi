using MangaReaderApi.Domain.Interfaces.utils;

namespace MangaReaderApi.Domain.utils;

public class Reader : IReader
{
    public StreamReader GetReader(string filePath) =>
        new StreamReader(filePath);

    public byte[] StreamReaderToArray(StreamReader sr)
    {
        using (var ms = new MemoryStream())
        {
            sr.BaseStream.CopyTo(ms);
            return ms.ToArray();
        }

    }
}

