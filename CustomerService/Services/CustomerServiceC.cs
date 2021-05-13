using CustomerApplication.Commands.CustomerCommands;
using CustomerApplication.Queries;
using CustomerDomain.Domain;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
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
                var result =  await _mediatR.Send(command);
                return result;
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
                var result =  await _mediatR.Send(command);
                return result;
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
                var result = await _mediatR.Send(command);
                return result;
            }
            catch (Exception ex)
            {
                Log.Error($"Não  foi possível deletar: {ex.StackTrace}");
                throw;
            }
          
        }

        public async Task<List<Customer>> Obter()
        {
            try
            {
                var query = new GetAllCustomersQuery();
                Log.Information("Obtendo todos os clientes...");
                var result =  await _mediatR.Send(query);
                return result;
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
                var result =  await _mediatR.Send(query);
                return result;
            }
            catch (Exception ex)
            {
                Log.Error($"Não foi possível encontrar o cliente com id: {id} - {ex.StackTrace}");
                throw;
            }
        }
    }
}
