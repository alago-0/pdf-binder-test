using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace PdfUtils
{
  public static class PdfBinder
  {
    public static byte[] BindPdfBytes(List<byte[]> pdfsBytes)
    {
      // Create new pdf and do actions on it
      using (var outPdf = new PdfDocument())
      {
        // Iterate over each input pdf
        foreach (var pdfBytes in pdfsBytes)
        {
          // Read pdf bytes as file
          using (var pdfStream = new MemoryStream(pdfBytes))
          {
            using (var inputPdf = PdfReader.Open(pdfStream, PdfDocumentOpenMode.Import))
            {
              CopyPdfPages(inputPdf, outPdf);
            }
          }
        }
        
        // Save as file (memory stream) and return bytes
        using (var outPdfStream = new MemoryStream())
        {
          outPdf.Save(outPdfStream, false);
          return outPdfStream.ToArray();
        }
      }
    }

    private static void CopyPdfPages(PdfDocument from,
                                     PdfDocument to)
    {
      foreach (var page in from.Pages)
      {
        to.AddPage(page);
      }
    }
  }
}
