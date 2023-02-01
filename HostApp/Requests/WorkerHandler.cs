using AppDLL.Entity;
using HostApp.Models;
using HostApp.Models.EmloyeeModels;
using RestPanda.Requests;
using RestPanda.Requests.Attributes;

namespace HostApp.Requests;
[RequestHandlerPath("/worker")]
internal class WorkerHandler : RequestHandler
{
    [Post("/orders")]
    public void GetOrders()
    {
        var body = Bind<AuthModel>();
        if (body is null)
        {
            Send(new AnswerModel(false, null, 401, "incorrect request"));
            return;
        }

        List<Order> orders = Order.GetToWorker(body.Login);
        if (orders is null)
        {
            Send(new AnswerModel(false, null, 401, "incorrect request"));
            return;
        }

        var orderModels = new List<WorkerOrderModel>();
        foreach (var item in orders)
        {
            var model = new WorkerOrderModel();
            model.Id = item.Id;
            model.QR = item.EmplQRCode;
            model.OrderTime = item.OrderTime;
            model.TimeToRecive = item.TimeTeDeliver;
            model.TimeToDeliver = item.TimeTeDeliver;
            model.AddressFrom = item.AddressFrom;
            model.AddressTo = item.AddressTo;
            model.Status = item.Status.Title;
            model.Login = body.Login;
            model.Commentary = item.Commentary;

            orderModels.Add(model);
        }

        Send(new AnswerModel(true, orderModels, null, null));
    }
    [Post("/accept")]
    public void AcceptOrder()
    {
        var body = Bind<WorkerOrderModel>();
        if (body is null)
        {
            Send(new AnswerModel(false, null, 401, "incorrect request"));
            return;
        }

        var order = Order.GetById(body.Id);
        order.TimeTeDeliver = body.TimeToDeliver;
        order.TimeToRecive = body.TimeToRecive;
        order.Status = Status.GetById(2);

        Order.Update(order);
        Send(new AnswerModel(true, order));
    }
    [Post("/recive")]
    public void ReciveOrder()
    {
        var body = Bind<WorkerOrderModel>();
        if (body is null)
        {
            Send(new AnswerModel(false, null, 401, "incorrect request"));
            return;
        }

        var order = Order.GetById(body.Id);
        order.TimeTeDeliver = body.TimeToDeliver;
        order.TimeToRecive = body.TimeToRecive;
        order.Status = Status.GetById(3);

        Order.Update(order);
        Send(new AnswerModel(true, order));
    }

    [Post("/deliver")]
    public void DeliverOrder()
    {
        var body = Bind<WorkerOrderModel>();
        if (body is null)
        {
            Send(new AnswerModel(false, null, 401, "incorrect request"));
            return;
        }

        var order = Order.GetById(body.Id);
        order.TimeTeDeliver = body.TimeToDeliver;
        order.TimeToRecive = body.TimeToRecive;
        order.Status = Status.GetById(4);

        Order.Update(order);
        Send(new AnswerModel(true, order));
    }
}