using MangaReaderApi.Domain.Dto;

namespace MangaReaderApi.Domain.Interfaces.Services;

public interface IServiceChapter
{
    bool DownloadChapter(GetMangaRequestDto mangaRequest);
}
