using CustomerApplication.Commands.UserCommands;
using CustomerDomain.Domain;
using CustomerDomain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerService.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AutheticateUserCommand model);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetByUsernameAndPassword(string username, string password);
        Task<User> GetById(int id);
        Task<RegisterResponse> Register(RegisterUserCommand model);
    }
}
