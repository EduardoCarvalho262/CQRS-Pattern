using System.Threading;
using System.Threading.Tasks;
using CustomerApplication.Queries.UserQueries;
using CustomerDomain.Entity;
using CustomerInfra.Repositories;
using MediatR;

namespace CustomerApplication.Handlers.UsersHandlersQueries
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IRepository<User> _userRepository;

        public GetUserByIdHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _userRepository.Get(request.Id);
            return result;
        }
    }
}