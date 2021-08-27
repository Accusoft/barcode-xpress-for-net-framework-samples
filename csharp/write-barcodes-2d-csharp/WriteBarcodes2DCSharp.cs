using System.Diagnostics.SymbolStore;
using Accusoft.BarcodeXpressSdk;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace WriteBarcodes2DCSharp
{
    class WriteBarcodes2DCSharp
    {
        static void Main(string[] args)
        {
            // Set Barcode Type and Value from the command line arguments, defaulting to Data Matrix Barcode if none are provided.
            string barcodeValue = "Barcode Value";

            // Create a new instance of the BarcodeXpress component.
            using (BarcodeXpress barcodeXpress = new BarcodeXpress("."))
            {
                // The SetSolutionName, SetSolutionKey and possibly the SetOEMLicenseKey methods must be
                // called to distribute the runtime. Note that the SolutionName, SolutionKey and
                // OEMLicenseKey values shown below are only examples.
                // barcodeXpress.Licensing.SetSolutionName("YourSolutionName");
                // barcodeXpress.Licensing.SetSolutionKey(0x00000001, 0x00000002, 0x00000003, 0x00000004);
                // barcodeXpress.Licensing.SetOEMLicenseKey("YourOEMLicenseKey");

                // Create a new Writer with the BarcodeXpress object, then use
                // it to create a new bitmap which will be saved to a file.
                using (WriterDataMatrix dmWriter = new WriterDataMatrix(barcodeXpress))
                {
                    // Provide the value you wish to encode in the bitmap.
                    dmWriter.BarcodeValue = barcodeValue;

                    // If you want to create a QR Code, you would instead use
                    // something like this to account for unicode characters:
                    //
                    //   qrWriter.BarcodeData = Encoding.UTF8.GetBytes(barcodeValue)
                    //

                    using (Bitmap bitmap = dmWriter.CreateBitmap())
                    {
                        bitmap.Save("test-barcodes.bmp", ImageFormat.Bmp);
                        Console.WriteLine("Barcode image has been created successfully");
                    }
                    
                }
            }
        }
    }
}
