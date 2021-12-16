using CustomerDomain.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApplication.Queries
{
    public class GetCustomerByIdQuery : IRequest<Customer>
    {
        public int Id { get; init; }
    }
}
