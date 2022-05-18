using System.Collections.Generic;
using MangaReaderApi.Domain.Services;
using MangaReaderApi.Domain.Exceptions;
using Moq;
using Xunit;
using MangaReaderApi.Domain.Interfaces.Services.Domain;
using MangaReaderApi.Domain.ValueObjects;

namespace MangaReaderApi.Tests.Domain;

public class ServiceSourceResolverTests
{
    IList<MangaSource> MangaSource = new List<MangaSource>
        { new MangaSource("SourceName", "//div/img") };

    private IServiceSourceResolver sut;

    public ServiceSourceResolverTests()
    {
        var jsonReader = new Mock<IServiceJasonReader>();
        jsonReader.Setup(sr => sr.LoadJson(It.IsAny<string>())).Returns(() => MangaSource);
        sut = new ServiceSourceResolver(jsonReader.Object);
    }

    [Fact]
    public void ShouldReturnOneSource()
    {
        var selectedSource = sut.ResolveSource("SourceName");

        Assert.Equal("SourceName", selectedSource.SourceName);
        Assert.Equal("//div/img", selectedSource.HtmlImageNode);
    }

    [Fact]
    public void ShouldReturnSourceNootFoundException()
    {
        Assert.Throws<SourceNotFoundException>(() => sut.ResolveSource(""));
    }
}