using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CustomerApplication.Queries.UserQueries;
using CustomerDomain.Entity;
using CustomerInfra.Repositories;
using MediatR;

namespace CustomerApplication.Handlers.UsersHandlersQueries
{
    public class GetUserByUsernameAndPasswordHandler : IRequestHandler<GetUserByUsernameAndPasswordQuery, User>
    {
        private readonly IRepository<User> _repository;

        public GetUserByUsernameAndPasswordHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<User> Handle(GetUserByUsernameAndPasswordQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetAll();

            var resp = user.FirstOrDefault(x => x.Username == request.Username && x.Password == request.Password);

            return resp;
        }
    }
}