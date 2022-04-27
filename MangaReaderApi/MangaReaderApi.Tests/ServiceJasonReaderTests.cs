using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MangaReaderApi.Application.Utils;
using MangaReaderApi.Domain.Dto;
using MangaReaderApi.Domain.Interfaces.Services;
using MangaReaderApi.Domain.Interfaces.utils;
using Moq;
using Xunit;

namespace MangaReaderApi.Tests;

public class ServiceJasonReaderTest
{
    static string fakeFileContents = "[{ 'SourceName': 'SourceName', 'HtmlImageNode': '//div/img' }]";
    static byte[] fakeFileBytes = Encoding.UTF8.GetBytes(fakeFileContents);
    MemoryStream fakeMemoryStream = new MemoryStream(fakeFileBytes);

    IList<GetMangaRequestDto> comparisonDto = new List<GetMangaRequestDto>
        { new GetMangaRequestDto("sourceName", "//div/img") };

    [Fact]
    public void ShouldReturnEmptyDtoList()
    {
        var reader = new Mock<IReader>();
        var sut = new ServiceJasonReader(reader.Object);

        IList<GetMangaRequestDto> dtoList = sut.LoadJson("");
        Assert.Empty(dtoList);
    }

    [Fact]
    public void ShouldReturnDtoList()
    {
        var reader = new Mock<IReader>();
        reader.Setup(sr => sr.GetReader(It.IsAny<string>())).Returns(() => new StreamReader(fakeMemoryStream));
        var sut = new ServiceJasonReader(reader.Object);

        IList<GetMangaRequestDto> dtoList = sut.LoadJson("file.json");
        Assert.NotEmpty(dtoList);
        Assert.Equal(comparisonDto, dtoList);
    }
}