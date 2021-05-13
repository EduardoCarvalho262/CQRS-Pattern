using CustomerApplication.Queries;
using CustomerDomain.Domain;
using CustomerInfra.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApplication.Handlers.CustomerHandlers
{
    public class GetAllCustomersHandlers : IRequestHandler<GetAllCustomersQuery, List<Customer>>
    {

        private readonly IRepository<Customer> _repo;

        public GetAllCustomersHandlers(IRepository<Customer> repo)
        {
            _repo = repo;
        }

        public async Task<List<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var result = await _repo.GetAll();
            return result;
        }
    }
}
