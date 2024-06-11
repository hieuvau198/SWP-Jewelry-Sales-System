using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ZXing;
using ZXing.Windows.Compatibility;

namespace JewelSystemBE.Controllers
{
    [Route("api/barcode")]
    [ApiController]
    public class BarcodeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GenerateBarcode(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return BadRequest("Input string cannot be null or empty.");
            }

            // Generate barcode image
            BarcodeWriter writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128 // You can choose the barcode format you prefer
            };
            var barcodeImage = writer.Write(input);

            // Convert the image to a byte array
            byte[] imageBytes;
            using (MemoryStream stream = new MemoryStream())
            {
                barcodeImage.Save(stream, ImageFormat.Png);
                imageBytes = stream.ToArray();
            }

            // Return the image bytes in the response
            return File(imageBytes, "image/png");
        }

        [HttpPost]
        public IActionResult VerifyBarcode([FromBody] BarcodeImageModel model)
        {
            try
            {
                byte[] imageBytes;

                if (!string.IsNullOrEmpty(model.ImageBase64))
                {
                    // Convert base64 string to byte array
                    imageBytes = Convert.FromBase64String(model.ImageBase64);
                }
                else if (model.ImageFile != null)
                {
                    // Read image file into byte array
                    imageBytes = model.ImageFile;
                }
                else
                {
                    return BadRequest("Image data not provided.");
                }

                // Decode barcode from image bytes
                using (var ms = new MemoryStream(imageBytes))
                {
                    using (var bitmap = new Bitmap(ms))
                    {
                        // Convert Bitmap to LuminanceSource
                        LuminanceSource source = new BitmapLuminanceSource(bitmap);
                        var reader = new BarcodeReader();
                        var result = reader.Decode(source);

                        if (result != null)
                        {
                            return Ok(result.Text); // Return barcode value
                        }
                        else
                        {
                            return NotFound("No barcode found in the provided image.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }

    public class BarcodeImageModel
    {
        public string ImageBase64 { get; set; }
        public byte[] ImageFile { get; set; } // For ASP.NET Core, this should be a byte array
    }
}
