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

    private IServiceSourceResolver service;

    public ServiceSourceResolverTests()
    {
        var jsonReader = new Mock<IServiceJasonReader>();
        jsonReader.Setup(sr => sr.LoadJson(It.IsAny<string>())).Returns(() => MangaSource);
        service = new ServiceSourceResolver(jsonReader.Object);
    }

    [Fact]
    public void ShouldReturnOneSource()
    {
        var selectedSource = service.ResolveSource("SourceName");

        Assert.Equal("SourceName", selectedSource.SourceName);
        Assert.Equal("//div/img", selectedSource.HtmlImageNode);
    }

    [Fact]
    public void ShouldReturnSourceNootFoundException()
    {
        Assert.Throws<SourceNotFoundException>(() => service.ResolveSource(""));
    }
}