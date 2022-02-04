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
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, Customer>
    {

        private readonly IRepository<Customer> _repository;

        public DeleteCustomerHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }


        public async Task<Customer> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.Delete(request.Id);
            return customer;
        }
    }
}
