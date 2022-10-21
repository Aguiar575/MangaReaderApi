
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

    public async Task<MemoryStream> CreateChapterPdfWithBytesAsync(
        IAsyncEnumerable<byte[]> chapterImagesBytes,
        DeviceFileFormats format) 
        {
            var conversor = GetConversor(format);
            
            if(conversor is not null)
                return await conversor.CreateChapterPdfWithBytesAsync(chapterImagesBytes);

            return new MemoryStream();

            IServicePdfConversor? GetConversor(DeviceFileFormats format) => 
                _servicePdfConversors.Where(e => e.deviceFormat == format).FirstOrDefault();
        }
}