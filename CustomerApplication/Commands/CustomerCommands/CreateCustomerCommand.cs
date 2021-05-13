using CustomerDomain.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApplication.Commands.CustomerCommands
{
    public class CreateCustomerCommand : IRequest<Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public CreateCustomerCommand(int id, string name, string phone)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
        }
    }
}
