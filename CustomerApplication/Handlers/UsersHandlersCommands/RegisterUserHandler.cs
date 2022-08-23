using CustomerApplication.Commands.UserCommands;
using CustomerDomain.Domain;
using CustomerDomain.Entity;
using CustomerInfra.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApplication.Handlers.UsersHandlersCommands
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, RegisterResponse>
    {
        private readonly IRepository<User> _repository;

        public RegisterUserHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<RegisterResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _repository.Add(new User(request.FirstName, request.LastName, request.Username ,request.Password, request.Role));

                if (response is null)
                {
                    return new RegisterResponse { Message = "Erro na criação" };
                }

                return new RegisterResponse { Message = "Usuário criado com sucesso"};
            }
            catch (System.Exception)
            {
                throw;
            } 
        }
    }
}
