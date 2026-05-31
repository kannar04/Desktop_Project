using System;
using System.Drawing;
using System.IO;
using QRCoder;

namespace DesktopApp_Project.BUS
{
    public class QrCodeService
    {
        public byte[] GenerateQrBytes(string paymentUrl)
        {
            if (string.IsNullOrWhiteSpace(paymentUrl))
            {
                throw new ArgumentException("Noi dung QR thanh toan khong duoc de trong.", "paymentUrl");
            }

            using (var generator = new QRCodeGenerator())
            using (var data = generator.CreateQrCode(paymentUrl, QRCodeGenerator.ECCLevel.M))
            using (var qrCode = new PngByteQRCode(data))
            {
                return qrCode.GetGraphic(20);
            }
        }

        public Bitmap GenerateQrBitmap(string paymentUrl)
        {
            var bytes = GenerateQrBytes(paymentUrl);
            using (var stream = new MemoryStream(bytes))
            using (var image = Image.FromStream(stream))
            {
                return new Bitmap(image);
            }
        }
    }
}
