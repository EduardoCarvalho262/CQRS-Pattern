using CustomerApplication.Queries;
using CustomerDomain.Domain;
using CustomerInfra.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApplication.Handlers.CustomerHandlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {

        private readonly IRepository<Customer> _repository;

        public GetCustomerByIdHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _repository.Get(request.Id);
                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }
    }
}
