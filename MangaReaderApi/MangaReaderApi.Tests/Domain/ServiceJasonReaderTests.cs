using System.Collections.Generic;
using System.IO;
using System.Text;
using MangaReaderApi.Domain.Interfaces.utils;
using MangaReaderApi.Domain.Services;
using MangaReaderApi.Domain.ValueObjects;
using Moq;
using Xunit;

namespace MangaReaderApi.Tests.Domain;

public class ServiceJasonReaderTests
{
    static string fakeFileContents = "[{ 'SourceName': 'SourceName', 'HtmlImageNode': '//div/img' }]";
    static byte[] fakeFileBytes = Encoding.UTF8.GetBytes(fakeFileContents);
    MemoryStream fakeMemoryStream = new MemoryStream(fakeFileBytes);

    IList<MangaSource> comparisonDto = new List<MangaSource>
        { new MangaSource("SourceName", "//div/img") };

    [Fact]
    public void ShouldReturnEmptyDtoList()
    {
        var reader = new Mock<IReader>();
        var sut = new ServiceJasonReader(reader.Object);

        IList<MangaSource> dtoList = sut.LoadJson("");
        Assert.Empty(dtoList);
    }

    [Fact]
    public void ShouldReturnDtoList()
    {
        var reader = new Mock<IReader>();
        reader.Setup(sr => sr.GetReader(It.IsAny<string>())).Returns(() => new StreamReader(fakeMemoryStream));
        var sut = new ServiceJasonReader(reader.Object);

        IList<MangaSource> dtoList = sut.LoadJson("file.json");
        Assert.NotEmpty(dtoList);
        Assert.Equal(comparisonDto, dtoList);
    }
}