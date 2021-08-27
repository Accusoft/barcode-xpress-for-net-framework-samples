Imports Accusoft.BarcodeXpressSdk

Module WriteBarcodes1DVB

    Sub Main()
        ' Create a new instance of the BarcodeXpress component.
        Using bx As BarcodeXpress = New Accusoft.BarcodeXpressSdk.BarcodeXpress(".")

            ' The SetSolutionName, SetSolutionKey and possibly the SetOEMLicenseKey methods must be
            ' called to distribute the runtime.  Note that the SolutionName, SolutionKey and 
            ' OEMLicenseKey values shown below are only examples.
            ' bx.Licensing.SetSolutionName("YourSolutionName")
            ' bx.Licensing.SetSolutionKey(1, 2, 3, 4)
            ' bx.Licensing.SetOEMLicenseKey("2.0.AStringForOEMLicensingContactAccusoftSalesForMoreInformation...")

            ' Set Barcode Type and Value from the command line arguments, defaulting to Code 39 if none are provided.
            bx.writer.BarcodeValue = "CODE39"
            bx.writer.BarcodeType = BarcodeType.Code39Barcode

            ' Create a Bitmap with BarcodeXpress
            Dim MyBitmap As System.Drawing.Bitmap = bx.writer.CreateBitmap()

            ' Save the created bitmap to a local file.
            MyBitmap.Save("test-barcodes.bmp")
            Console.WriteLine("Barcode image has been created successfully")
        End Using
    End Sub

End Module
