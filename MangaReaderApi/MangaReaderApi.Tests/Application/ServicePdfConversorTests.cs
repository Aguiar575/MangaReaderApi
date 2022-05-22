using System.Collections.Generic;
using System.IO;
using MangaReaderApi.Application.Services;
using MangaReaderApi.Domain.Interfaces.Services.Application;
using MangaReaderApi.Domain.Interfaces.utils;
using MangaReaderApi.Domain.utils;
using MangaReaderApi.Tests.TestHelpers;
using Xunit;

namespace MangaReaderApi.Tests.Application;

public class ServicePdfConversorTests : AssemblyLocationHelper
{
    private readonly IReader _reader;
    private readonly IServicePdfConversor _servicePdfConversor;

    public ServicePdfConversorTests()
    {
        _reader = new Reader();
        _servicePdfConversor = new ServicePdfConversor();
    }

    [Fact]
    public void ShouldReturnPdfNotEmptyMemoryStream()
    {
        string verticalMangaPage = FindFileByRelativePath("/TestFiles/vertical_manga_page.png");

        using (var rd = _reader.GetReader(verticalMangaPage))
        {
            var bytes = new List<byte[]>() { _reader.StreamReaderToArray(rd) };
            using (MemoryStream mangaChapterPdf = _servicePdfConversor.CreateChapterPdfWithBytes(bytes))
            {
                Assert.True(mangaChapterPdf.Length > 0);
            }
        }
    }
}

