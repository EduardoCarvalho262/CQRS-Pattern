using CustomerApplication.Commands.CustomerCommands;
using CustomerApplication.Queries;
using CustomerDomain.Domain;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.Services
{
    public class CustomerServiceC : ICustomerService
    {

        private readonly IMediator _mediatR;

        public CustomerServiceC(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        public async Task<Customer> Atualizar(Customer cliente)
        {
            try
            {
                var command = new UpdateCustomerCommand(cliente.Id, cliente.Name, cliente.Phone);
                Log.Information("Atualizando Cliente...");
                var customer =  await _mediatR.Send(command);
                Log.Information("Cliente atualizado com sucesso.");
                return customer;
            }
            catch (Exception ex)
            {
                Log.Error($"Não foi possível atualizar {ex.StackTrace}");
                throw;
            }

        }

        public async Task<Customer> Criar(Customer cliente)
        {
            try
            {
                var command = new CreateCustomerCommand(cliente.Id, cliente.Name, cliente.Phone);
                Log.Information("Criando Cliente...");
                var customer =  await _mediatR.Send(command);
                Log.Information("Cliente criado com sucesso.");
                return customer;
            }
            catch (Exception ex)
            {
                Log.Error($"Não foi possível criar um cliente: {ex.StackTrace}");
                throw;
            }

        }

        public async Task<Customer> Deletar(int id)
        {
            try
            {
                var command = new DeleteCustomerCommand(id);
                Log.Information("Deletando Cliente...");
                var customer = await _mediatR.Send(command);
                Log.Information("Cliente deletado com sucesso.");
                return customer;
            }
            catch (Exception ex)
            {
                Log.Error($"Não  foi possível deletar: {ex.StackTrace}");
                throw;
            }
          
        }

        public async Task<List<Customer>> ObterTodos()
        {
            try
            {
                var query = new GetAllCustomersQuery();
                Log.Information("Obtendo todos os clientes...");
                var customer =  await _mediatR.Send(query);
                Log.Information("Clientes Obtidos com sucesso.");
                return customer;
            }
            catch (Exception ex)
            {
                Log.Error($"Não foi possível obter clientes: {ex.StackTrace}");
                throw;
            }


        }

        public async Task<Customer> ObterPorId(int id)
        {
            try
            {
                var query = new GetCustomerByIdQuery { Id = id };
                Log.Information($"Buscando cliente com id: {id}");
                var customer =  await _mediatR.Send(query);
                Log.Information($"Cliente com id: {id} foi encontrando com sucesso.");
                return customer;
            }
            catch (Exception ex)
            {
                Log.Error($"Não foi possível encontrar o cliente com id: {id} - {ex.StackTrace}");
                throw;
            }
        }
    }
}
