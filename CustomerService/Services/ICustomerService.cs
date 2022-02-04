using CustomerDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> ObterTodos();
        Task<Customer> ObterPorId(int id);
        Task<Customer> Atualizar(Customer customer);
        Task<Customer> Criar(Customer customer);
        Task<Customer> Deletar(int id);
    }
}
