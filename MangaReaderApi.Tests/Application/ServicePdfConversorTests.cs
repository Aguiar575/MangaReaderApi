using System.Collections.Generic;
using System.IO;
using MangaReaderApi.Application.Services;
using MangaReaderApi.Domain.utils;
using MangaReaderApi.Tests.TestHelpers;
using Xunit;

namespace MangaReaderApi.Tests.Application;

public class ServicePdfConversorTests : AssemblyLocationHelper
{
    [Fact]
    public void ShouldReturnPdfNotEmptyMemoryStream()
    {
        string verticalMangaPage = FindFileByRelativePath("/TestFiles/vertical_manga_page.png");

        var _reader = new Reader();
        var _servicePdfConversor = new ServiceKindlePdfConversor();

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

