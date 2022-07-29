using System.Collections.Generic;
using MangaReaderApi.Domain.Services;
using MangaReaderApi.Domain.Exceptions;
using Moq;
using Xunit;
using MangaReaderApi.Domain.ValueObjects;
using MangaReaderApi.Domain.Interfaces.Services;

namespace MangaReaderApi.Tests.Domain;

public class ServiceSourceResolverTests
{
    [Fact]
    public void ResolveSource_Should_Return_One_Source()
    {
        IList<MangaSource> MangaSource = new List<MangaSource>
        { new MangaSource("SourceName", "//div/img") };

        var jsonReader = new Mock<IServiceJasonReader>();
        jsonReader.Setup(sr => sr.LoadJson(It.IsAny<string>())).Returns(() => MangaSource);
        var sut = new ServiceSourceResolver(jsonReader.Object);

        var selectedSource = sut.ResolveSource("SourceName");

        Assert.Equal("SourceName", selectedSource.SourceName);
        Assert.Equal("//div/img", selectedSource.HtmlImageNode);
    }

    [Fact]
    public void ResolveSource_Should_Return_Source_Not_Found_Exception()
    {
        var jsonReader = new Mock<IServiceJasonReader>();
        jsonReader.Setup(sr => sr.LoadJson(It.IsAny<string>())).Returns(() => new List<MangaSource>());
        var sut = new ServiceSourceResolver(jsonReader.Object);

        Assert.Throws<SourceNotFoundException>(() => sut.ResolveSource(""));
    }
}