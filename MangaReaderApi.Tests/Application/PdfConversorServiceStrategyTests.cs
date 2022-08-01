using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using MangaReaderApi.Application.Factory;
using MangaReaderApi.Application.Interfaces.Services;
using MangaReaderApi.Domain.Enum;
using Moq;
using System.Linq;
using Xunit;

namespace MangaReaderApi.Tests.Application;

public class PdfConversorServiceStrategyTests
{
    [Fact]
    public async void CreateChapterPdfWithBytesAsync_Should_Return_Empty_MemortStream_If_PdfConversor_Was_Not_Found()
    {
        var pdfConversors = new List<IServicePdfConversor>();

        var sut = new PdfConversorServiceStrategy(pdfConversors);

        MemoryStream result = await sut.CreateChapterPdfWithBytesAsync(new List<byte[]>().ToAsyncEnumerable(),
                                                                       DeviceFileFormats.Kindle);

        Assert.Equal(0, result.Length);
    }

    [Fact]
    public async Task CreateChapterPdfWithBytesAsync_Should_Call_CreateChapterPdfWithBytesAsync_Of_Conversor_If_Conversor_Was_Found()
    {
        var pdfConversor = new Mock<IServicePdfConversor>();
        pdfConversor.Setup(sr => sr.CreateChapterPdfWithBytesAsync(It.IsAny<IAsyncEnumerable<byte[]>>()))
            .Returns(() => Task.FromResult(new MemoryStream()));
        pdfConversor.Setup(sr => sr.deviceFormat)
            .Returns(DeviceFileFormats.Kindle);
        
        var pdfConversors = new List<IServicePdfConversor>() { pdfConversor.Object };

        var sut = new PdfConversorServiceStrategy(pdfConversors);

        MemoryStream result = await sut.CreateChapterPdfWithBytesAsync(new List<byte[]>().ToAsyncEnumerable(), DeviceFileFormats.Kindle);

        pdfConversor.Verify(e => e.CreateChapterPdfWithBytesAsync(It.IsAny<IAsyncEnumerable<byte[]>>()), Times.Once);
    }
}

