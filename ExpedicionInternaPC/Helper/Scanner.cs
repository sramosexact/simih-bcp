using WIA;

namespace ExpedicionInternaPC
{

    public class Scanner
    {
        CommonDialog dlg;
        public Scanner()
        {
            dlg = new CommonDialog();

        }
        public System.Drawing.Image Scann(WiaImageBias Size)
        {
            ImageFile imageFile = dlg.ShowAcquireImage(WiaDeviceType.ScannerDeviceType,
            WiaImageIntent.ColorIntent, Size,
            "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}", true, false, false);

            Vector vector = imageFile.FileData;
            System.Drawing.Image i = System.Drawing.Image.FromStream(new
            System.IO.MemoryStream((byte[])vector.get_BinaryData()));
            return i;
        }
    }
}
