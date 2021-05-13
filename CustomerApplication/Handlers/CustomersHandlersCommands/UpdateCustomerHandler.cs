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
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Customer>
    {
        private readonly IRepository<Customer> _repo;

        public UpdateCustomerHandler(IRepository<Customer> repo)
        {
            _repo = repo;
        }

        public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repo.Get(request.Id);
            cliente.Name = request.Name;
            cliente.Phone = request.Phone;

            await _repo.Update(cliente);

            return cliente;
        }
    }
}
