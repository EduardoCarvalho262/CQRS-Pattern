 using CustomerDomain.Domain;
using CustomerService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerControler : ControllerBase
    {
        //Injeção de dependência
        private readonly ICustomerService _customerService;

        public CustomerControler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<List<Customer>> Get()
        {
            var result = await _customerService.Obter();
            Log.Information("Clientes Obtidos com sucesso.");

            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {

            var c =   await _customerService.ObterPorId(id);

            if (c == null)
            {
                Log.Warning("Cliente não encontrado.");
                return NotFound();
            }

            Log.Information($"Cliente com id: {id} foi encontrando com sucesso.");
            return Ok(c);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Post(Customer cliente)
        {
            var result =  await _customerService.Criar(cliente);
            Log.Information("Cliente criado com sucesso.");
            return CreatedAtAction("Get", result.Id);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> Put(int id, Customer cliente)
        {

            if (id != cliente.Id)
            {
                Log.Warning("Não foi possível atualizar o cliente.");
                return BadRequest();
            }

            await _customerService.Atualizar(cliente);
            Log.Information("Cliente atualizado com sucesso.");

            return NoContent();

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> Delete(int id)
        {
            var cliente = await _customerService.Deletar(id);


            if (cliente == null)
            {
                Log.Warning("Cliente inexistente, impossível deletar.");
                return NotFound();
            }

            Log.Information("Cliente deletado com sucesso.");
            return NoContent();
        }

    }
}
