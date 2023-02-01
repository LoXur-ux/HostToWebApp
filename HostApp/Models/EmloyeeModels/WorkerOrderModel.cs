namespace HostApp.Models.EmloyeeModels;
public class WorkerOrderModel
{
    public int Id { get; set; }
    public string QR { get; set; }
    public string Commentary { get; set; }
    public DateTime OrderTime { get; set; }
    public DateTime? TimeToRecive { get; set; }
    public DateTime? TimeToDeliver { get; set; }
    public string AddressFrom { get; set; }
    public string AddressTo { get; set; }
    public string Status { get; set; }
    public string Login { get; set; }
}
