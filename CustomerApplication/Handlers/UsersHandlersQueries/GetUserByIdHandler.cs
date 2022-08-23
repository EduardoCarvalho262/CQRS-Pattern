using CustomerApplication.Queries.UserQueries;
using CustomerDomain.Entity;
using CustomerInfra.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApplication.Handlers.UsersHandlersQueries
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IRepository<User> _repository;

        public GetUserByIdHandler(IRepository<User> repository)
        {
            _repository = repository;
        }
        
        public Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = _repository.Get(request.Id);

            return user;
        }
    }
}
