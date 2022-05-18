using System.Collections.Generic;
using MangaReaderApi.Domain.Interfaces.Services.Application;
using Moq;
using Xunit;

namespace MangaReaderApi.Tests.Application;

public class ServicePdfConversorTests
{
    [Fact]
    public void ShouldCreatePdfAndReturnTrue()
    {
        var sut = new Mock<IServicePdfConversor>();
        var bytes = new List<byte[]>();

        var pdf = sut.Object.CreateChapterPdf(bytes);

        Assert.True(pdf);
    }
}

