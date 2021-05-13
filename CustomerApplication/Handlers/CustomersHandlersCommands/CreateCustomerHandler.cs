using CustomerApplication.Commands.CustomerCommands;
using CustomerDomain.Domain;
using CustomerInfra.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApplication.Handlers.CustomersHandlersCommands
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {

        private readonly IRepository<Customer> _repo;

        public CreateCustomerHandler(IRepository<Customer> repo)
        {
            _repo = repo;
        }

        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var cliente = new Customer(request.Name, request.Phone);

            await _repo.Add(cliente);

            return cliente;
        }
    }
}
