﻿using MangaReaderApi.Domain.Dto;

namespace MangaReaderApi.Domain.Interfaces.Services.Application;

public interface IServiceChapter
{
    bool GetChapterPdf(GetMangaChapterRequest request);
}
