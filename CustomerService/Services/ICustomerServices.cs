using CustomerApplication.Commands.CustomerCommands;
using CustomerApplication.Response.Command;
using CustomerApplication.Response.Query;
using CustomerDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Services
{
    public interface ICustomerServices
    {
        Task<CustomerQueryResult> ObterTodos();
        Task<CustomerQueryResult> ObterPorId(int id);
        Task<CustomerCommandResult> Atualizar(UpdateCustomerCommand customer);
        Task<CustomerCommandResult> Criar(CreateCustomerCommand customer);
        Task<CustomerCommandResult> Deletar(int id);
    }
}
