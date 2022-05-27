using CustomerApplication.Commands.CustomerCommands;
using CustomerApplication.Queries;
using CustomerApplication.Response.Command;
using CustomerApplication.Response.Query;
using CustomerDomain.Domain;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CustomerService.Services
{
    public class CustomerServices : ICustomerServices
    {

        private readonly IMediator _mediatR;

        public CustomerServices(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        public async Task<CustomerCommandResult> Atualizar(UpdateCustomerCommand command)
        {
            try
            {
                var customer = new CustomerCommandResult();

                Log.Information("Atualizando Cliente...");
                var response =  await _mediatR.Send(command);

                Log.Information("Cliente atualizado com sucesso.");
                customer.Status = HttpStatusCode.NoContent.ToString();
                customer.Mensagem = "Cliente Atualizado!";

                return customer;
            }
            catch (Exception ex)
            {
                Log.Error($"Não foi possível atualizar {ex.StackTrace}");
                var customerError = new CustomerCommandResult();

                customerError.Status = HttpStatusCode.BadRequest.ToString();
                customerError.Mensagem = ex.Message;
                return customerError;
            }
        }

        public async Task<CustomerCommandResult> Criar(CreateCustomerCommand command)
        {
            try
            {
                var customer = new CustomerCommandResult();

                Log.Information("Criando Cliente...");
                var response =  await _mediatR.Send(command);

                Log.Information("Cliente criado com sucesso.");
                customer.Status = HttpStatusCode.Created.ToString();
                customer.Mensagem = "Cliente Criado!";

                return customer;
            }
            catch (Exception ex)
            {
                Log.Error($"Não foi possível criar um cliente: {ex.Message}");
                var customerError = new CustomerCommandResult();

                customerError.Status = HttpStatusCode.BadRequest.ToString();
                customerError.Mensagem = ex.Message;
                
                return customerError;
            }
        }

        public async Task<CustomerCommandResult> Deletar(int id)
        {
            try
            {
                var customer = new CustomerCommandResult();
                var command = new DeleteCustomerCommand(id);

                Log.Information("Deletando Cliente...");
                var response = await _mediatR.Send(command);

                Log.Information("Cliente deletado com sucesso.");

                customer.Status = HttpStatusCode.NoContent.ToString();
                customer.Mensagem = "Cliente Deletado!";

                return customer;
            }
            catch (Exception ex)
            {
                Log.Error($"Não  foi possível deletar: {ex.Message}");
                var customerError = new CustomerCommandResult();

                customerError.Status = HttpStatusCode.BadRequest.ToString();
                customerError.Mensagem = ex.Message;
                return customerError;
            }
        }

        public async Task<CustomerQueryResult> ObterTodos()
        {
            try
            {
                var customer = new CustomerQueryResult();
                var query = new GetAllCustomersQuery();

                Log.Information("Obtendo todos os clientes...");
                var response =  await _mediatR.Send(query);

                Log.Information("Clientes Obtidos com sucesso.");

                customer.Status = HttpStatusCode.OK.ToString();
                customer.Customers = response;

                return customer;
            }
            catch (Exception ex)
            {
                Log.Error($"Não foi possível obter clientes: {ex.Message}");
                var customerError = new CustomerQueryResult();

                customerError.Status = HttpStatusCode.NotFound.ToString();
                customerError.Mensagem = ex.Message;

                return customerError;
            }
        }

        public async Task<CustomerQueryResult> ObterPorId(int id)
        {
            try
            {
                var customer = new CustomerQueryResult();
                customer.Customers = new List<Customer>();

                var query = new GetCustomerByIdQuery { Id = id };

                Log.Information($"Buscando cliente com id: {id}");
                var response =  await _mediatR.Send(query);

                Log.Information($"Cliente com id: {id} foi encontrando com sucesso.");
                customer.Status = HttpStatusCode.OK.ToString();
                customer.Customers.Add(response);

                return customer;
            }
            catch (Exception ex)
            {
                Log.Error($"Não foi possível encontrar o cliente com id: {id} - {ex.Message}");
                var customerError = new CustomerQueryResult();

                customerError.Status = HttpStatusCode.NotFound.ToString();
                customerError.Mensagem = ex.Message;

                return customerError;
            }
        }
    }
}
