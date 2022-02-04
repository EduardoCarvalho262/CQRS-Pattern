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
        
        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var command = new CreateUserCommand(model.Username, model.Password);
            var autheticateResponse =  await _mediator.Send(command);
            return autheticateResponse;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var query = new GetAllUsersQuery();
            var users = await _mediator.Send(query);

            return users;
        }

        public async Task<User> GetById(int id)
        {
            var query = new GetUserByIdQuery(id);
            var user = await _mediator.Send(query);

            return user;
        }
    }
}
