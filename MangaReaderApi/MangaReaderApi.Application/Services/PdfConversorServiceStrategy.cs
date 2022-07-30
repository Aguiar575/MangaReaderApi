
using MangaReaderApi.Application.Interfaces.Services;
using MangaReaderApi.Domain.Enum;

namespace MangaReaderApi.Application.Factory;

public class PdfConversorServiceStrategy : IPdfConversorServiceStrategy
{
    private readonly IEnumerable<IServicePdfConversor> _servicePdfConversors;

    public PdfConversorServiceStrategy(IEnumerable<IServicePdfConversor> servicePdfConversors)
    {
        _servicePdfConversors = servicePdfConversors;
    }

    public MemoryStream CreateChapterPdfWithBytes(
        IEnumerable<byte[]> chapterImagesBytes,
        DeviceFileFormats format) 
        {
            var conversor = GetConversor(format);
            
            if(conversor is not null)
                return conversor.CreateChapterPdfWithBytes(chapterImagesBytes);

            return new MemoryStream();

            IServicePdfConversor? GetConversor(DeviceFileFormats format) => 
                _servicePdfConversors.Where(e => e.deviceFormat == format).FirstOrDefault();
        }
}