using MangaReaderApi.Domain.Dto;
using MangaReaderApi.Domain.Exceptions;
using MangaReaderApi.Domain.Interfaces.Facades.Application;
using MangaReaderApi.Domain.Interfaces.Services.Application;

namespace MangaReaderApi.Application.Services;

public class MangaService : IMangaService
{
    private readonly IChapterContentExtractor _chapterContentExtractor;
    private readonly IServicePdfConversor _servicePdfConversor;

    public MangaService(IChapterContentExtractor chapterContentExtractor,
                           IServicePdfConversor servicePdfConversor)
    {
        _chapterContentExtractor = chapterContentExtractor;
        _servicePdfConversor = servicePdfConversor;
    }
    public byte[] GetChapter(GetMangaChapterRequest request)
    {   
        IEnumerable<byte[]> chapterContent = _chapterContentExtractor.GetChapterImageBytes(request);

        using (var chapterFile = _servicePdfConversor.CreateChapterPdfWithBytes(chapterContent))
        {
            if(chapterFile is null)
                throw new CouldNotRenderChapterException();

            return chapterFile.ToArray();
        }
    }
}

