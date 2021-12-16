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
        private readonly IRepository<User> _userRepository;

        public GetAllUsersHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.GetAll();
            return result;
        }
    }
}