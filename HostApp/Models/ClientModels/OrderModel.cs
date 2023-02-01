namespace HostApp.Models.ClientModels;
public class OrderModel
{
    public int Id { get; set; }
    public string AddressFrom { get; set; }
    public string AddressTo { get; set; }
    public decimal Price { get; set; }
    public string QRCode { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; }
    public string Commentary { get; set; }
    public string Login { get; set; }
}