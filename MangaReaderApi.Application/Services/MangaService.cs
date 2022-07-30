using MangaReaderApi.Application.Interfaces.Services;
using MangaReaderApi.Domain.Dto;
using MangaReaderApi.Domain.Enum;
using MangaReaderApi.Domain.Exceptions;
using MangaReaderApi.Domain.Interfaces.Facades.Application;

namespace MangaReaderApi.Application.Services;

public class MangaService : IMangaService
{
    private readonly IChapterContentExtractor _chapterContentExtractor;
    private readonly IPdfConversorServiceStrategy _pdfConversorServiceStrategy;

    public MangaService(IChapterContentExtractor chapterContentExtractor, 
                        IPdfConversorServiceStrategy pdfConversorServiceStrategy)
    {
        _chapterContentExtractor = chapterContentExtractor;
        _pdfConversorServiceStrategy = pdfConversorServiceStrategy;
    }

    public byte[] GetPdfChapter(GetMangaChapterRequest request, DeviceFileFormats format)
    {   
        IEnumerable<byte[]> chapterContent = _chapterContentExtractor.GetChapterImageBytes(request);

        using (var chapterFile = _pdfConversorServiceStrategy.CreateChapterPdfWithBytes(chapterContent, format))
        {
            return chapterFile.ToArray();
        }
    }
}

