using CustomerDomain.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApplication.Commands.CustomerCommands
{
    public class DeleteCustomerCommand : IRequest<Customer>
    {
        public int Id { get; set; }


        public DeleteCustomerCommand(int id)
        {
            this.Id = id;
        }
    }
}
