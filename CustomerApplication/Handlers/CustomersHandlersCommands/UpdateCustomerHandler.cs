using CustomerApplication.Commands.CustomerCommands;
using CustomerDomain.Domain;
using CustomerInfra.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApplication.Handlers.CustomersHandlersCommands
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Customer>
    {
        private readonly IRepository<Customer> _repository;

        public UpdateCustomerHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _repository.Get(request.Id);
                customer.Name = request.Name;
                customer.Phone = request.Phone;

                var response = await _repository.Update(customer);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
        }
    }
}
