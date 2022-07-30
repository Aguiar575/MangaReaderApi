using iTextSharp.text;
using iTextSharp.text.pdf;
using MangaReaderApi.Application.Interfaces.Services;
using MangaReaderApi.Domain.Enum;

namespace MangaReaderApi.Application.Services;

public class ServiceKindlePdfConversor : IServicePdfConversor
{
    public DeviceFileFormats deviceFormat => DeviceFileFormats.Kindle;

    public MemoryStream CreateChapterPdfWithBytes(IEnumerable<byte[]> ChapterImagesBytes)
    {
        var pdfStream = new MemoryStream();

        using (var doc = new Document(PageSize.A4))
        {
            PdfWriter writer = PdfWriter.GetInstance(doc, pdfStream);
            writer.CloseStream = false;

            doc.Open();

            foreach (var image in ChapterImagesBytes)
            {
                Image img = Image.GetInstance(image);
                float scalePercent = (((doc.PageSize.Width / img.Width) * 100) - 4);

                img.ScalePercent(scalePercent);
                doc.Add(img);
            }

            doc.CloseDocument();
        }

        return pdfStream;
    }
}

