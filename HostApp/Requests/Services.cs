using AppDLL;
using AppDLL.Entity;
using HostApp.Models;
using HostApp.Models.ClientModels;
using RestPanda.Requests;
using RestPanda.Requests.Attributes;
using System.Text;

namespace HostApp.Requests;
[RequestHandlerPath("/services")]
public class Services : RequestHandler
{
    [Post("/get-report")]
    public void GetReport()
    {
        var body = Bind<ClientModel>();
        if (body is null)
        {
            Send(new AnswerModel(false, null, 401, "incorrect request"));
            return;
        }

        var res = Convert.ToBase64String(ExcelWorker.Generate(Client.GetByLogin(body.Login).Human, Order.GetAllByLogin(body.Login)));
        Send(new AnswerModel(true, res, null, null));
    }
}
