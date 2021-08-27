Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Text
Imports Accusoft.BarcodeXpressSdk

Module WriteBarcodes2DVB

    Sub Main()
        ' Set Barcode Type and Value from the command line arguments, defaulting to Data Matrix Barcode if none are provided.
        Dim barcodeValue = "Barcode Value"

        ' Create a new instance of the BarcodeXpress component.
        Using barcodeXpress As BarcodeXpress = New BarcodeXpress(".")
            ' The SetSolutionName, SetSolutionKey and possibly the SetOEMLicenseKey methods must be
            ' called to distribute the runtime.  Note that the SolutionName, SolutionKey and
            ' OEMLicenseKey values shown below are only examples.
            ' barcodeXpress.Licensing.SetSolutionName("YourSolutionName")
            ' barcodeXpress.Licensing.SetSolutionKey(1, 2, 3, 4)
            ' barcodeXpress.Licensing.SetOEMLicenseKey("YourOEMLicenseKey")

            ' Create a barcode using specific Barcode Xpress 2D writer.
            Using dmWriter As WriterDataMatrix = New WriterDataMatrix(barcodeXpress)
                ' Provide the desired barcode value.
                dmWriter.BarcodeValue = barcodeValue

                ' If you want to create a QR Code, you would instead use
                ' something like this to account for unicode characters:
                '
                '   qrWriter.BarcodeData = Encoding.UTF8.GetBytes(barcodeValue)
                '

                ' Create a new bitmap using the writer and save it to a file.
                Using bitmap As Bitmap = dmWriter.CreateBitmap()
                    bitmap.Save("test-barcodes.bmp", ImageFormat.Bmp)
                    Console.WriteLine("Barcode Image has been created successfully.")
                End Using

            End Using

        End Using

    End Sub

End Module
