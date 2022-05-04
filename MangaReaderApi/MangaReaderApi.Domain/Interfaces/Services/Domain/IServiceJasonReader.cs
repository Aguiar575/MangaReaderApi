using MangaReaderApi.Domain.Dto;

namespace MangaReaderApi.Domain.Interfaces.Services.Domain;

public interface IServiceJasonReader
{
    IList<GetMangaRequestDto> LoadJson(string filePath);
}

