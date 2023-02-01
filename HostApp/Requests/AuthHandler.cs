using AppDLL.Entity;
using HostApp.Models;
using HostApp.Models.ClientModels;
using RestPanda.Requests;
using RestPanda.Requests.Attributes;
using Trivial.Security;

namespace HostApp.Requests;

[RequestHandlerPath("/auth")]
public class AuthHandler : RequestHandler
{
    private (string, string) GenerateToken(Client client)
    {
        var model = new JsonWebTokenPayload
        {
            Id = Guid.NewGuid().ToString("n"),
            Issuer = client.Human.Login,
            Expiration = DateTime.Now + new TimeSpan(1, 0, 0)
        };
        var refreshModel = new JsonWebTokenPayload
        {
            Id = Guid.NewGuid().ToString("n"),
            Issuer = client.Human.Login,
            Expiration = DateTime.Now + new TimeSpan(30, 0, 0)
        };

        var jwt = new JsonWebToken<JsonWebTokenPayload>(model, Program.Sign);
        var refresh_jwt = new JsonWebToken<JsonWebTokenPayload>(refreshModel, Program.Sign);
        AuthToken.AddToken(refresh_jwt.ToEncodedString(), client);
        return (jwt.ToEncodedString(), refresh_jwt.ToEncodedString());
    }

    private (string, string) RefreshTokenCheck(string token)
    {
        var client = AuthToken.ContainsToken(token);
        return client is null ? ("", "") : GenerateToken(client);
    }

    [Post("/signup")]
    public void Registration()
    {
        var body = Bind<RegistrationModel>();
        if (RegistrationModel.Check(body))
        {
            Send(new AnswerModel(false, null, 401, "incorrect request"));
            return;
        }

        Human human = new();
        human.Login = body.Login;
        human.Password = body.Password;
        human.Email = body.Email;
        human.Role = Role.GetById(1);
        if (!body.IsAnonimus)
        {
            human.FirstName = body.FirstName;
            human.MidName = body.MidName;
            human.LastName = body.LastName;
            human.PhoneNamber = body.PhoneNumber;
        }

        Client client = new();
        client.IsAnonimus = body.IsAnonimus;
        client.Human = human;
        Email.SendCode(client.Human.Email);
        if (!Client.Add(client))
        {
            Send(new AnswerModel(false, null, 401, "incorrect request"));
            return;
        }

        var token = GenerateToken(client);
        Send(new AnswerModel(true,
            new
            {
                access_token = token.Item1,
                refresh_token = token.Item2,
                user = client.IsAnonimus
                ? new ClientModel(client.Id, client.IsAnonimus,
                client.Human.Login, client.Human.Email)
                : new ClientModel(client.Id, client.Human.Role.Id, client.IsAnonimus,
                client.Human.Login, client.Human.Email,
                client.Human.FirstName, client.Human.MidName, client.Human.LastName, client.Human.PhoneNamber)
            }, null, null));
    }

    [Post("/signin")]
    public void Login()
    {
        var body = Bind<AuthModel>();
        if (body.Login is null && body.Password is null)
        {
            Send(new AnswerModel(false, null, 400, "incorrect request"));
            return;
        }

        var client = Client.Get(body.Login, body.Password);
        if (client is null)
        {
            Send(new AnswerModel(false, null, 401, "incorrect request"));
            return;
        }

        var token = GenerateToken(client);
        Send(new AnswerModel(true,
            new
            {
                access_token = token,
                user = client.IsAnonimus
                ? new ClientModel(client.Id, client.IsAnonimus,
                client.Human.Login, client.Human.Email)
                : new ClientModel(client.Id, client.Human.Role.Id, client.IsAnonimus,
                client.Human.Login, client.Human.Email,
                client.Human.FirstName, client.Human.MidName, client.Human.LastName, client.Human.PhoneNamber)
            }, null, null));
    }
}
