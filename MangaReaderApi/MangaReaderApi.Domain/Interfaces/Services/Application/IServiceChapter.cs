using MangaReaderApi.Domain.ValueObjects;

namespace MangaReaderApi.Domain.Interfaces.Services.Application;

public interface IServiceChapter
{
    bool SendChapterToEmail(MangaSource mangaRequest);
}
