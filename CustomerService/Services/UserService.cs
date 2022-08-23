using CustomerDomain.Domain;
using CustomerDomain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerApplication.Commands.UserCommands;
using CustomerApplication.Queries.UserQueries;
using MediatR;

namespace CustomerService.Services
{
    public class UserService : IUserService
    {

        private readonly IMediator _mediator;
        public UserService(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task<AuthenticateResponse> Authenticate(AutheticateUserCommand command)
        {
            var autheticateResponse =  await _mediator.Send(command);
            return autheticateResponse;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var query = new GetAllUsersQuery();
            var users = await _mediator.Send(query);

            return users;
        }

        public async Task<User> GetByUsernameAndPassword(string username, string password)
        {
            var query = new GetUserByUsernameAndPasswordQuery(username, password);
            var user = await _mediator.Send(query);

            return user;
        }

        public async Task<User> GetById(int id)
        {
            var query = new GetUserByIdQuery();
            var user = await _mediator.Send(query);

            return user;
        }

        public async Task<RegisterResponse> Register(RegisterUserCommand command)
        {
            var response = await _mediator.Send(command);
            return response;
        }
    }
}
