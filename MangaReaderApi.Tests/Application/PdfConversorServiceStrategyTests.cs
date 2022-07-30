using System.Collections.Generic;
using System.IO;
using MangaReaderApi.Application.Factory;
using MangaReaderApi.Application.Interfaces.Services;
using MangaReaderApi.Domain.Enum;
using Moq;
using Xunit;

namespace MangaReaderApi.Tests.Application;

public class PdfConversorServiceStrategyTests
{
    [Fact]
    public void CreateChapterPdfWithBytes_Should_Return_Empty_MemortStream_If_PdfConversor_Was_Not_Found()
    {
        var pdfConversors = new List<IServicePdfConversor>();

        var sut = new PdfConversorServiceStrategy(pdfConversors);

        MemoryStream result = sut.CreateChapterPdfWithBytes(new List<byte[]>(), DeviceFileFormats.Kindle);

        Assert.Equal(0, result.Length);
    }

    [Fact]
    public void CreateChapterPdfWithBytes_Should_Call_CreateChapterPdfWithBytes_Of_Conversor_If_Conversor_Was_Found()
    {
        var pdfConversor = new Mock<IServicePdfConversor>();
        pdfConversor.Setup(sr => sr.CreateChapterPdfWithBytes(It.IsAny<List<byte[]>>()))
            .Returns(() => new MemoryStream());
        pdfConversor.Setup(sr => sr.deviceFormat)
            .Returns(DeviceFileFormats.Kindle);
        
        var pdfConversors = new List<IServicePdfConversor>() { pdfConversor.Object };

        var sut = new PdfConversorServiceStrategy(pdfConversors);

        MemoryStream result = sut.CreateChapterPdfWithBytes(new List<byte[]>(), DeviceFileFormats.Kindle);

        pdfConversor.Verify(e => e.CreateChapterPdfWithBytes(It.IsAny<List<byte[]>>()), Times.Once);
    }
}

