Imports Accusoft.BarcodeXpressSdk
Imports Newtonsoft.Json
Imports System
Imports System.Drawing
Imports System.Reflection

Module ReadBarcodesVB

    ' Takes an argument for an image path, then prints out any barcodes found on that image.
    Sub Main(args As String())
        Dim imagePath As String = "test-barcodes.bmp"
        ' Search all types of barcodes in an image file (by default all 1D barcodes).
        ' For the full list of options, see the API reference
        ' at https://help.accusoft.com/BarcodeXpress/latest/BxNetFramework/webframe.html#api-reference.html
        Using barcodeXpress As BarcodeXpress = New BarcodeXpress("."),
                bitmap As Bitmap = New Bitmap(imagePath)

            ' The SetSolutionName, SetSolutionKey and possibly the SetOEMLicenseKey methods must be
            ' called to distribute the runtime.  Note that the SolutionName, SolutionKey and 
            ' OEMLicenseKey values shown below are only examples.
            ' barcodeXpress.Licensing.SetSolutionName("YourSolutionName")
            ' barcodeXpress.Licensing.SetSolutionKey(1, 2, 3, 4)
            ' barcodeXpress.Licensing.SetOEMLicenseKey("YourOEMLicenseKey")

            barcodeXpress.reader.BarcodeTypes = System.Enum.GetValues(GetType(BarcodeType))

            Dim results As Accusoft.BarcodeXpressSdk.Result() = barcodeXpress.reader.Analyze(bitmap)

            Console.WriteLine("Results:")
            Console.WriteLine(JsonConvert.SerializeObject(results, Formatting.Indented))
        End Using
    End Sub

End Module
