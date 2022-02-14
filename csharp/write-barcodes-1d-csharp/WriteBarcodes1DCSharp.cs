using System;
using Accusoft.BarcodeXpressSdk;

namespace WriteBarcodes1DCSharp
{
    class WriteBarcodes1DCSharp
    {
        static void Main(string[] args)
        {
            // Create a new instance of the BarcodeXpress component.
            using (BarcodeXpress bx = new BarcodeXpress("."))
            {
                // The SetSolutionName, SetSolutionKey and possibly the SetOEMLicenseKey methods must be
                // called to distribute the runtime.  Note that the SolutionName, SolutionKey and 
                // OEMLicenseKey values shown below are only examples.
                //bx.Licensing.SetSolutionName("YourSolutionName");
                //bx.Licensing.SetSolutionKey(1, 2, 3, 4);
                //bx.Licensing.SetOEMLicenseKey("2.0.AStringForOEMLicensingContactAccusoftSalesForMoreInformation...");

                // Set Barcode Type and Value to Code 39. 
                bx.writer.BarcodeValue = "CODE39";
                bx.writer.BarcodeType = BarcodeType.Code39Barcode;

                // Create a Bitmap with Barcode Xpress.
                System.Drawing.Bitmap bitmap = bx.writer.CreateBitmap();

                // Save the created bitmap to a local file.
                bitmap.Save("test-barcodes.bmp");
                Console.WriteLine("Barcode image has been created successfully");
                Console.WriteLine("Press enter to exit...");
                Console.ReadLine();
            }
        }
    }
}
