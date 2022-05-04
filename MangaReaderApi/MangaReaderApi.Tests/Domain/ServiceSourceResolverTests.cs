using System.Collections.Generic;
using MangaReaderApi.Domain.Services;
using MangaReaderApi.Domain.Dto;
using MangaReaderApi.Domain.Exceptions;
using MangaReaderApi.Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace MangaReaderApi.Tests.Domain;

public class ServiceSourceResolverTests
{
    IList<GetMangaRequestDto> requestDto = new List<GetMangaRequestDto>
        { new GetMangaRequestDto("SourceName", "//div/img") };

    private IServiceSourceResolver service;

    public ServiceSourceResolverTests()
    {
        var jsonReader = new Mock<IServiceJasonReader>();
        jsonReader.Setup(sr => sr.LoadJson(It.IsAny<string>())).Returns(() => requestDto);
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