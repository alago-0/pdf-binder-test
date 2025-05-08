using PdfUtils;

var basePath = @"C:\Users\UserPC\Desktop\Job\Projects\StareCivila\TestPdf\";
var files = new List<string>
{ 
  @"Files\amd.pdf",
  @"Files\dell.pdf",
  @"Files\nvidia.pdf"
};
List<byte[]> pdfsBytes = new();
foreach (var file in files)
{
  var path = basePath + file;
  var pdfBytes = File.ReadAllBytes(path);
  pdfsBytes.Add(pdfBytes);
}

var bindedPdf = PdfBinder.BindPdfBytes(pdfsBytes);
using (FileStream fs = File.Create(basePath + "test.pdf"))
{
  fs.Write(bindedPdf, 0, bindedPdf.Length);
}
