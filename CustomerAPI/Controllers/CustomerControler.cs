 using CustomerDomain.Domain;
using CustomerService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 using CustomerAPI.Helpers;

 namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerControler : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerControler(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        
        [HttpGet]
        public async Task<List<Customer>> GetAll()
        {
            return await _customerService.ObterTodos();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            var c =   await _customerService.ObterPorId(id);
            return Ok(c);
        }
        
        [HttpPost]
        public async Task<ActionResult<Customer>> Post(Customer cliente)
        {
            var result =  await _customerService.Criar(cliente);
            return CreatedAtAction("Get", result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> Put(int id, Customer cliente)
        {
            await _customerService.Atualizar(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> Delete(int id)
        {
            var cliente = await _customerService.Deletar(id);
            return NoContent();
        }

    }
}
