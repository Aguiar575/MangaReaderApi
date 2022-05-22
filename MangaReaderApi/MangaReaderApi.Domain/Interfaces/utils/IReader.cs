using System;
namespace MangaReaderApi.Domain.Interfaces.utils;

public interface IReader
{
    StreamReader GetReader(string filePath);
    byte[] StreamReaderToArray(StreamReader sr);
}

