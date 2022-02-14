Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Text
Imports Accusoft.BarcodeXpressSdk

Module KanjiKanaEncodeDecodeVB

    Sub Main()
        Dim qrCodeImagePath As String = "test-barcodes.bmp"
        Dim kanjiString As String = "日本語の漢字 - Barcode Xpress Sample  "

        ' Current console font might not have support of Kanji/Kana symbols.
        ' If you don't see the correct output
        ' change Console window -> Properties -> Font to another TrueType font with Japanese symbols support,
        ' e.g. "MS Gothic".
        Console.OutputEncoding = Encoding.UTF8

        ' Create a new instance of the BarcodeXpress component.
        Using barcodeXpress As BarcodeXpress = New BarcodeXpress(".")
            ' Barcode Xpress runs in Watermark evaluation mode if started without a license
            ' and the barcode value will be partially hidden.
            ' The SetSolutionName, SetSolutionKey and possibly the SetOEMLicenseKey methods must be
            ' called to distribute the runtime. Note that the SolutionName, SolutionKey and
            ' OEMLicenseKey values shown below are only examples.
            ' barcodeXpress.Licensing.SetSolutionName("YourSolutionName")
            ' barcodeXpress.Licensing.SetSolutionKey(1, 2, 3, 4)
            ' barcodeXpress.Licensing.SetOEMLicenseKey("YourOEMLicenseKey")

            ' Create a QR Code with a barcode value containing Kanji symbols.
            Using qrWriter As WriterQRCode = New WriterQRCode(barcodeXpress)
                ' Encode Kanji/Kana string into a sequence of bytes and use BarcodeData property to create a barcode with binary data.
                qrWriter.BarcodeData = Encoding.GetEncoding("Shift_JIS").GetBytes(kanjiString)

                Using qrBitmap As Bitmap = qrWriter.CreateBitmap()
                    qrBitmap.Save(qrCodeImagePath, ImageFormat.Bmp)
                    Console.WriteLine("QR Code image with Kanji string has been created successfully: {0}.", qrCodeImagePath)
                End Using
            End Using

            ' Recognize a QR Code image with a barcode value containing Kanji symbols.
            Using bitmap As Bitmap = New Bitmap(qrCodeImagePath)
                barcodeXpress.reader.BarcodeTypes = New BarcodeType() {BarcodeType.QRCodeBarcode}

                Dim results As Accusoft.BarcodeXpressSdk.Result() = barcodeXpress.reader.Analyze(bitmap)

                For i = 0 To results.GetUpperBound(0)
                    ' Use BarcodeDataAsByte to get the recognized barcode data value in bytes and decode it.
                    ' Note: Barcode Xpress does not not know what type of encoding is supposed to be used for the data.
                    ' Determining the correct encoding is the responsibility of the application.
                    Console.WriteLine("Recognized barcode value: {0}", Encoding.GetEncoding("Shift_JIS").GetString(results(i).BarcodeDataAsByte))
                Next
            End Using

        End Using

        Console.WriteLine("Press enter to exit...")
        Console.ReadLine()

    End Sub

End Module
