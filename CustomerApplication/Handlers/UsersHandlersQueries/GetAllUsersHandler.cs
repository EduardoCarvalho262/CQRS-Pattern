using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CustomerApplication.Queries.UserQueries;
using CustomerDomain.Entity;
using CustomerInfra.Repositories;
using MediatR;

namespace CustomerApplication.Handlers.UsersHandlersQueries
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IRepository<User> _repository;

        public GetAllUsersHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAll();
            return users;
        }
    }
}