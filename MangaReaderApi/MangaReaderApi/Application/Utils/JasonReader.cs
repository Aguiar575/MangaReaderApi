using MangaReaderApi.Domain.Dto;
using Newtonsoft.Json;

namespace MangaReaderApi.Application.Utils;

public class JasonReader
{
    public IList<GetMangaRequestDto> LoadJson()
    {
        using (StreamReader r = new StreamReader("file.json"))
        {
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<List<GetMangaRequestDto>>(json);
        }
    }
}

