using System;
using System.Collections.Generic;
using MangaReaderApi.Application.Services;
using MangaReaderApi.Domain.Dto;
using MangaReaderApi.Domain.Exceptions;
using MangaReaderApi.Domain.Interfaces.Facades.Application;
using MangaReaderApi.Domain.Interfaces.Services.Application;
using MangaReaderApi.Domain.Interfaces.Services.Domain;
using MangaReaderApi.Domain.Services.Factories;
using MangaReaderApi.Domain.ValueObjects;
using MangaReaderApi.Tests.TestHelpers;
using Moq;
using Xunit;

namespace MangaReaderApi.Tests.Application;

public class MangaServiceTests : AssemblyLocationHelper
{
    private const string SCRAPE_THIS = "https://books.toscrape.com/catalogue/a-light-in-the-attic_1000/index.html";

    [Fact]
    public void Should_Return_ArgumentException_When_Request_Is_Null()
    {
        var chapterContentExtractor = new Mock<IChapterContentExtractor>();
        chapterContentExtractor.Setup(sr => sr.GetChapterImageBytes(It.IsAny<GetMangaChapterRequest>())).Returns(() => new List<byte[]>());

        var servicePdfConversor = new Mock<IServicePdfConversor>();
        servicePdfConversor.Setup(sr => sr.CreateChapterPdfWithBytes(It.IsAny<IEnumerable<byte[]>>())).Returns(() => null);

        var sut = new MangaService(chapterContentExtractor.Object, servicePdfConversor.Object);

        MangaSource mangaSource = new MangaSource("MangaSource", "//div/img");
        var serviceSourceResolver = new Mock<IServiceSourceResolver>();
        serviceSourceResolver.Setup(sr => sr.ResolveSource(It.IsAny<string>()))
            .Returns(mangaSource);
        var chapterMangaDtoFactory = new ChapterMangaDtoFactory(serviceSourceResolver.Object);
        var mangaRequestDto = chapterMangaDtoFactory.Create(SCRAPE_THIS, "MangaSource");

        Assert.Throws<CouldNotRenderChapterException>(() => sut.GetChapter(mangaRequestDto));
    }
}

