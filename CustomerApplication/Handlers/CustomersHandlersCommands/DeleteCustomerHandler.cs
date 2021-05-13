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

        private readonly IRepository<Customer> _repo;

        public DeleteCustomerHandler(IRepository<Customer> repo)
        {
            _repo = repo;
        }


        public async Task<Customer> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var result = await _repo.Delete(request.Id);
            return result;
        }
    }
}
