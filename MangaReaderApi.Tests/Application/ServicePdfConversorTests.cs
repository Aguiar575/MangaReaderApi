using System.Collections.Generic;
using System.IO;
using MangaReaderApi.Application.Services;
using MangaReaderApi.Domain.utils;
using MangaReaderApi.Tests.TestHelpers;
using Xunit;
using System.Linq;
using System.Threading.Tasks;

namespace MangaReaderApi.Tests.Application;

public class ServicePdfConversorTests : AssemblyLocationHelper
{
    [Fact]
    public async Task ShouldReturnPdfNotEmptyMemoryStreamAsync()
    {
        string verticalMangaPage = FindFileByRelativePath("/TestFiles/vertical_manga_page.png");

        var _reader = new Reader();
        var _servicePdfConversor = new ServiceKindlePdfConversor();

        using (var rd = _reader.GetReader(verticalMangaPage))
        {
            var bytes = new List<byte[]>() { _reader.StreamReaderToArray(rd) };
            using (MemoryStream mangaChapterPdf = await _servicePdfConversor.CreateChapterPdfWithBytesAsync(bytes.ToAsyncEnumerable()))
            {
                Assert.True(mangaChapterPdf.Length > 0);
            }
        }
    }
}

