using System;
using MangaReaderApi.Domain.Interfaces.utils;

namespace MangaReaderApi.Application.Utils
{
	public class Reader : IReader
	{
		public StreamReader GetReader(string filePath) =>
			new StreamReader(filePath);
	}
}

