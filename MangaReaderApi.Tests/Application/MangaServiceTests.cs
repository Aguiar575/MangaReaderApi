using System.Collections.Generic;
using MangaReaderApi.Application.Interfaces.Services;
using MangaReaderApi.Application.Services;
using MangaReaderApi.Domain.Dto;
using MangaReaderApi.Domain.Exceptions;
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
    public void Should_Return_ArgumentException_When_Request_Is_Null()
    {
        var chapterContentExtractor = new Mock<IChapterContentExtractor>();
        chapterContentExtractor.Setup(sr => sr.GetChapterImageBytes(It.IsAny<GetMangaChapterRequest>())).Returns(() => new List<byte[]>());

        var servicePdfConversor = new Mock<IServicePdfConversor>();
        servicePdfConversor.Setup(sr => sr.CreateChapterPdfWithBytes(It.IsAny<IEnumerable<byte[]>>())).Returns(() => null);

        var sut = new MangaService(chapterContentExtractor.Object, servicePdfConversor.Object);

        MangaSource mangaSource = new MangaSource("MangaSource", "//div/img");
        var mangaRequestDto = ChapterDtoFixtureFactory.Create("SomeUrl", mangaSource);

        Assert.Throws<CouldNotRenderChapterException>(() => sut.GetPdfChapter(mangaRequestDto));
    }
}

