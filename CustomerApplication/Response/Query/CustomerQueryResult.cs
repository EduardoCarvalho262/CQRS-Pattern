using CustomerDomain.Domain;
using System.Collections;
using System.Collections.Generic;

namespace CustomerApplication.Response.Query
{
    public class CustomerQueryResult
    {
        public IList<Customer> Customers { get; set; }
        public string Status { get; set; }
        public string Mensagem { get; set; }
    }
}
