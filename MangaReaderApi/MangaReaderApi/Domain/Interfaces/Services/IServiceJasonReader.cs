using MangaReaderApi.Domain.Dto;

namespace MangaReaderApi.Domain.Interfaces.Services;

public interface IServiceJasonReader
{
    IList<GetMangaRequestDto> LoadJson(string filePath);
}

