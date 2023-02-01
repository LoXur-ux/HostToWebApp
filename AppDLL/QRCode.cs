using QRCoder;

namespace AppDLL;
public class QRCode
{
    public static string Generate(string value, int num)
    {
        QRCodeGenerator generator = new QRCodeGenerator();
        QRCodeData data = generator.CreateQrCode(Convert.ToString(value + "/" +  num), QRCodeGenerator.ECCLevel.Q);
        Base64QRCode base64 = new(data);
        return base64.GetGraphic(10);
    }

    public static bool Compare(string origin, string req)
        => origin.Equals(req);
}
