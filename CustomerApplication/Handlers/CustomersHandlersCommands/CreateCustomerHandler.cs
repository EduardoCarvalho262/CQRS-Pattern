using CustomerApplication.Commands.CustomerCommands;
using CustomerDomain.Domain;
using CustomerInfra.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApplication.Handlers.CustomersHandlersCommands
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {

        private readonly IRepository<Customer> _repository;

        public CreateCustomerHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = new Customer(request.Name, request.Phone);

                var response = await _repository.Add(customer);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }
    }
}
