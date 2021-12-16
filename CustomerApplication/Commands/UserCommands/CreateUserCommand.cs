using CustomerDomain.Domain;
using MediatR;

namespace CustomerApplication.Commands.UserCommands
{
    public class CreateUserCommand : IRequest<AuthenticateResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public CreateUserCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}