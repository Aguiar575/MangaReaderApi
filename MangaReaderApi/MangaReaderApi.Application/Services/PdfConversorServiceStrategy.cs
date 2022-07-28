
using MangaReaderApi.Application.Interfaces.Services;

namespace MangaReaderApi.Application.Factory;

public class PdfConversorServiceStrategy
{
    private readonly IEnumerable<IServicePdfConversor> _servicePdfConversors;

    public PdfConversorServiceStrategy(IEnumerable<IServicePdfConversor> servicePdfConversors)
    {
        _servicePdfConversors = servicePdfConversors;
    }
}