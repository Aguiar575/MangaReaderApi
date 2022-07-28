using MangaReaderApi.Application.Interfaces.Services;
using MangaReaderApi.Domain.Dto;
using MangaReaderApi.Domain.Exceptions;
using MangaReaderApi.Domain.Interfaces.Facades.Application;

namespace MangaReaderApi.Application.Services;

public class MangaService : IMangaService
{
    private readonly IChapterContentExtractor _chapterContentExtractor;
    private readonly IServicePdfConversor _serviceKindlePdfConversor;

    public MangaService(IChapterContentExtractor chapterContentExtractor,
                           IServicePdfConversor serviceKindlePdfConversor)
    {
        _chapterContentExtractor = chapterContentExtractor;
        _serviceKindlePdfConversor = serviceKindlePdfConversor;
    }
    public byte[] GetPdfChapter(GetMangaChapterRequest request)
    {   
        IEnumerable<byte[]> chapterContent = _chapterContentExtractor.GetChapterImageBytes(request);

        using (var chapterFile = _serviceKindlePdfConversor.CreateChapterPdfWithBytes(chapterContent))
        {
            if(chapterFile is null)
                throw new CouldNotRenderChapterException();

            return chapterFile.ToArray();
        }
    }
}

