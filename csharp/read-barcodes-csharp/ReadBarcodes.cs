using Accusoft.BarcodeXpressSdk;
using Newtonsoft.Json;
using System;
using System.Drawing;

namespace ReadBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Search for specific types of barcodes in an image file (by default all 1D barcodes).
            // For the full list of options, see the API reference
            // at https://help.accusoft.com/BarcodeXpress/latest/BxNetFramework/webframe.html#api-reference.html
            using (BarcodeXpress barcodeXpress = new BarcodeXpress("."))
            using (Bitmap bitmap = new Bitmap("test-barcodes.bmp"))
            {
                barcodeXpress.reader.BarcodeTypes = new BarcodeType[]
                {
                    BarcodeType.Code39Barcode,
                    BarcodeType.IntelligentMailBarcode,
                    BarcodeType.Code128Barcode,
                    BarcodeType.DataMatrixBarcode,
                    BarcodeType.QRCodeBarcode
                };
                Accusoft.BarcodeXpressSdk.Result[] results = barcodeXpress.reader.Analyze(bitmap);

                Console.WriteLine("Results:");
                Console.WriteLine(JsonConvert.SerializeObject(results, Formatting.Indented));
            }
        }
    }
}
