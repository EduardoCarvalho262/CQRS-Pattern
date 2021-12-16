using CustomerDomain.Domain;
using CustomerDomain.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerApplication.Commands.UserCommands;
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
            var response =  await _mediator.Send(command);
            return response;
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
