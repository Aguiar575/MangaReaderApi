using iTextSharp.text;
using iTextSharp.text.pdf;
using MangaReaderApi.Domain.Interfaces.Services.Application;

namespace MangaReaderApi.Application.Services;

public class ServicePdfConversor : IServicePdfConversor
{
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
                doc.Add(img);
            }

            doc.CloseDocument();
        }

        return pdfStream;
    }
}

