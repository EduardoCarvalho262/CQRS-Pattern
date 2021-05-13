using CustomerDomain.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApplication.Commands.CustomerCommands
{
    public class UpdateCustomerCommand : IRequest<Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public UpdateCustomerCommand(int id,string name, string phone)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
        }
    }
}
