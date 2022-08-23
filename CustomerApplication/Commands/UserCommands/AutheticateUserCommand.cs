using CustomerDomain.Domain;
using MediatR;

namespace CustomerApplication.Commands.UserCommands
{
    public class AutheticateUserCommand : IRequest<AuthenticateResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public AutheticateUserCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}