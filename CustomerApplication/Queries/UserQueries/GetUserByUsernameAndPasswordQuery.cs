using CustomerDomain.Entity;
using MediatR;

namespace CustomerApplication.Queries.UserQueries
{
    public class GetUserByUsernameAndPasswordQuery : IRequest<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public GetUserByUsernameAndPasswordQuery(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}