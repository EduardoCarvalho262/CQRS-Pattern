using CustomerApplication.Commands.CustomerCommands;
using CustomerDomain.Domain;
using CustomerService.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerControler : ControllerBase
    {
        private readonly ICustomerServices _customerService;

        public CustomerControler(ICustomerServices customerService)
        {
            _customerService = customerService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listaCustomers = await _customerService.ObterTodos();

            if (listaCustomers.Status != HttpStatusCode.OK.ToString())
                return NotFound(listaCustomers);

            return Ok(listaCustomers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _customerService.ObterPorId(id);

            if(customer.Status != HttpStatusCode.OK.ToString())
                return NotFound(customer);

            return Ok(customer.Customers.FirstOrDefault());
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerCommand cliente)
        {
            var response = await _customerService.Criar(cliente);

            if(response.Status != HttpStatusCode.NoContent.ToString())
                return BadRequest(response);

            return CreatedAtAction(nameof(Post), response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCustomerCommand cliente)
        {
            var response = await _customerService.Atualizar(cliente);

            if(response.Status != HttpStatusCode.NoContent.ToString())
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerService.Deletar(id);

            if (customer.Status != HttpStatusCode.NoContent.ToString())
                return BadRequest(customer);

            return Ok(customer);
        }
    }
}
