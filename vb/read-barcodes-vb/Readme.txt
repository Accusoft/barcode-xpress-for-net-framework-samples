ReadBarcodesVB is a minimal Barcode Xpress for .NET application which detects barcodes on a given bitmap image.

Requirements
-------------------------------------------------------------------------------------------------------

Visual Studio 2012-2019 to build the sample.

For the full list of requirements to run the sample, refer to the Barcode Xpress for .NET help.

Running the Sample
-------------------------------------------------------------------------------------------------------
First, open the solution file (ReadBarcodesVB.sln) in Visual Studio and build it.
This will also restore required the NuGet packages.

Then, open the Command Prompt window, change the directory to the sample output location (by default this is ReadBarcodesVB/bin/Debug),
and start the app:

.\ReadBarcodesVB.exe

You also can pass in the path of an image as an argument to test your own images:

.\ReadBarcodesVB.exe path\to\your\image.bmp

This will run the sample and you should see output like this:

Results:
[
  {
    "Area": "1992, 829, 426, 128",
    "Point1": "1992, 829",
    "Point2": "2418, 829",
    "Point3": "2418, 957",
    "Point4": "1992, 957",
    "Skew": 0,
    "Confidence": 100,
    "ValidCheckSum": false,
    "NumberCheckSumChars": 0,
    "Length": 31,
    "BarcodeValue": "V3TX** UNLICENSED accusoft.com",
    "BarcodeData": [
      "V",
      "3",
      "T",
      "X",
      "*",
      "*",
      " ",
      "U",
      "N",
      "L",
      "I",
      "C",
      "E",
      "N",
      "S",
      "E",
      "D",
      " ",
      "a",
      "c",
      "c",
      "u",
      "s",
      "o",
      "f",
      "t",
      ".",
      "c",
      "o",
      "m",
      "\u0000"
    ],
    "BarcodeDataAsByte": "VjNUWCoqIFVOTElDRU5TRUQgYWNjdXNvZnQuY29tAA==",
    "BarcodeName": "Code 39",
    "BarcodeType": 9,
    "ModeTransitions": [],
    "Info2D": {
      "RowsDetected": 0,
      "ColumnsDetected": 0,
      "Rows": 0,
      "Columns": 0,
      "ErrorCorrectionLevel": 0
    }
  },
  ...
]

NOTE: Barcode Xpress runs in Watermark evaluation mode if started without a license and the barcode value will be partially hidden.
If you would like to do a full-featured evaluation of the product, contact us: mailto:info@accusoft.com
