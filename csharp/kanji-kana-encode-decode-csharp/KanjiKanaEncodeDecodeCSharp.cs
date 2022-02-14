using Accusoft.BarcodeXpressSdk;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace KanjiKanaEncodeDecodeCSharp
{
    class KanjiKanaEncodeDecodeCSharp
    {
        static void Main()
        {
            const string qrCodeImagePath = "test-barcodes.bmp";
            const string kanjiString = "日本語の漢字 - Barcode Xpress Sample  ";

            // Current console font might not have support of Kanji/Kana symbols.
            // If you don't see the correct output
            // change Console window -> Properties -> Font to another TrueType font with Japanese symbols support,
            // e.g. "MS Gothic".
            Console.OutputEncoding = Encoding.UTF8;

            // Create a new instance of the BarcodeXpress component.
            using (BarcodeXpress barcodeXpress = new BarcodeXpress("."))
            {
                // Barcode Xpress runs in Watermark evaluation mode if started without a license
                // and the barcode value will be partially hidden.
                // The SetSolutionName, SetSolutionKey and possibly the SetOEMLicenseKey methods must be
                // called to distribute the runtime. Note that the SolutionName, SolutionKey and
                // OEMLicenseKey values shown below are only examples.
                //barcodeXpress.Licensing.SetSolutionName("YourSolutionName");
                //barcodeXpress.Licensing.SetSolutionKey(0x00000001, 0x00000002, 0x00000003, 0x00000004);
                //barcodeXpress.Licensing.SetOEMLicenseKey("YourOEMLicenseKey");

                // Create a QR Code with a barcode value containing Kanji symbols.
                using (WriterQRCode qrWriter = new WriterQRCode(barcodeXpress))
                {
                    // Encode Kanji/Kana string into a sequence of bytes and use BarcodeData property to create a barcode with binary data.
                    qrWriter.BarcodeData = Encoding.GetEncoding("Shift_JIS").GetBytes(kanjiString);
                    using (Bitmap qrBitmap = qrWriter.CreateBitmap())
                    {
                        qrBitmap.Save(qrCodeImagePath, ImageFormat.Bmp);
                        Console.WriteLine("QR Code image with Kanji string has been created successfully: {0}.", qrCodeImagePath);
                    }
                }

                // Recognize a QR Code image with a barcode value containing Kanji symbols.
                using (Bitmap bitmap = new Bitmap(qrCodeImagePath))
                {
                    barcodeXpress.reader.BarcodeTypes = new BarcodeType[] { BarcodeType.QRCodeBarcode };

                    Accusoft.BarcodeXpressSdk.Result[] results = barcodeXpress.reader.Analyze(bitmap);

                    for (int i = 0; i < results.Length; i++)
                    {
                        // Use BarcodeDataAsByte to get the recognized barcode data value in bytes and decode it.
                        // Note: Barcode Xpress does not not know what type of encoding is supposed to be used for the data.
                        // Determining the correct encoding is the responsibility of the application.
                        Console.WriteLine("Recognized barcode value: {0}", Encoding.GetEncoding("Shift_JIS").GetString(results[i].BarcodeDataAsByte));
                    }
                }
            }
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
