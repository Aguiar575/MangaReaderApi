using System.Collections.Generic;
using System.IO;
using MangaReaderApi.Application.Interfaces.Services;
using MangaReaderApi.Application.Services;
using MangaReaderApi.Domain.Dto;
using MangaReaderApi.Domain.Enum;
using MangaReaderApi.Domain.Interfaces.Facades.Application;
using MangaReaderApi.Domain.ValueObjects;
using MangaReaderApi.Tests.Fixture;
using MangaReaderApi.Tests.TestHelpers;
using Moq;
using Xunit;

namespace MangaReaderApi.Tests.Application;

public class MangaServiceTests : AssemblyLocationHelper
{
    [Fact]
    public void Should_Return_Empty_Array_Byte_When_Request_Return_Nothing()
    {
        var chapterContentExtractor = new Mock<IChapterContentExtractor>();
        chapterContentExtractor.Setup(sr => sr.GetChapterImageBytes(It.IsAny<GetMangaChapterRequest>()))
            .Returns(() => new List<byte[]>());

        var servicePdfConversor = new Mock<IPdfConversorServiceStrategy>();
        servicePdfConversor.Setup(sr => sr.CreateChapterPdfWithBytes(It.IsAny<IEnumerable<byte[]>>(), It.IsAny<DeviceFileFormats>()))
            .Returns(() => new MemoryStream());

        var sut = new MangaService(chapterContentExtractor.Object, servicePdfConversor.Object);

        MangaSource mangaSource = new MangaSource("MangaSource", "//div/img");
        var mangaRequestDto = ChapterDtoFixtureFactory.Create("SomeUrl", mangaSource);


        byte[] result = sut.GetPdfChapter(mangaRequestDto, DeviceFileFormats.Kindle);
        Assert.Empty(result);
    }
}

