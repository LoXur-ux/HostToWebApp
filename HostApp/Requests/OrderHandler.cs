using AppDLL;
using AppDLL.Entity;
using HostApp.Models;
using HostApp.Models.ClientModels;
using RestPanda.Requests;
using RestPanda.Requests.Attributes;

namespace HostApp.Requests;

[RequestHandlerPath("/order")]
public class OrderHandler : RequestHandler
{
    [Post("/add-order")]
    public void AddOrder()
    {
        var body = Bind<OrderModel>();
        if (body is null)
        {
            Send(new AnswerModel(false, null, 401, "incorrect request"));
            return;
        }

        Order order = new();
        order.Id = Order.GetLastIndex() + 1;
        order.AddressFrom = body.AddressFrom;
        order.AddressTo = body.AddressTo;
        order.Price = body.Price;
        order.OrderTime = DateTime.Now;
        order.Commentary = body.Commentary;
        order.Status = Status.GetById(1);
        order.Client = Client.GetByLogin(body.Login);
        order.ClientQRCode = QRCode.Generate(body.Login, order.Id);
        order.Employer = Human.SetEmloyeeToOrder();
        order.EmplQRCode = QRCode.Generate(order.Employer.Login, order.Id);
        if (!Order.Add(order))
        {
            Send(new AnswerModel(false, null, 401, "incorrect request"));
            return;
        }

        Send(new AnswerModel(true, order, null, null));
    }

    [Post("/get-all")]
    public void GetAll()
    {
        var body = Bind<AuthModel>();
        if (body is null)
        {
            Send(new AnswerModel(false, null, 401, "incorrect request"));
            return;
        }

        List<Order> orders = Order.GetAllByLogin(body.Login);
        List<OrderModel> models = new List<OrderModel>();
        if (orders is not null)
            foreach (var item in orders)
            {
                var order = new OrderModel();
                order.Id = item.Id;
                order.AddressFrom = item.AddressFrom;
                order.AddressTo = item.AddressTo;
                order.OrderDate = item.OrderTime;
                order.Commentary = item.Commentary!;
                order.QRCode = item.ClientQRCode;
                order.Price = item.Price;
                order.Status = item.Status.Title;
                models.Add(order);
            }

        Send(new AnswerModel(true, models, null, null));
    }
}
