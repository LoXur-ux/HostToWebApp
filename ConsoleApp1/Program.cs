public void Main()
{

}


public static string QRCodeGenerate()
{
    var str = SHA256((DateTime.Now.Ticks + new Random(88723541).Next()).ToString());
    QRCodeGenerator qrGenerator = new();
    QRCodeData qrData = qrGenerator.CreateQrCode(str, QRCodeGenerator.ECCLevel.M);
    QRCode qrCode = new QRCode(qrData);
    qrCode.ToString()
    }