using CustomerApplication.Queries;
using CustomerDomain.Domain;
using CustomerInfra.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApplication.Handlers.CustomerHandler
{
    public class GetAllCustomersHandler : IRequestHandler<GetAllCustomersQuery, List<Customer>>
    {

        private readonly IRepository<Customer> _repository;

        public GetAllCustomersHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<List<Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            try
            {
               var customers = await _repository.GetAll();
               return customers;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
    }
}
