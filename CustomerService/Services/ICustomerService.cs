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
        Task<List<Customer>> Obter();
        Task<Customer> ObterPorId(int id);
        Task<Customer> Atualizar(Customer cliente);
        Task<Customer> Criar(Customer cliente);
        Task<Customer> Deletar(int id);
    }
}
