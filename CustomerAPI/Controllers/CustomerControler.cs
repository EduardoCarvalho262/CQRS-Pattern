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
        //Injeção de dependência
        private readonly ICustomerService _customerService;

        public CustomerControler(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        
        [Authorize]
        [HttpGet]
        public async Task<List<Customer>> Get()
        {
            return await _customerService.Obter();
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            var c =   await _customerService.ObterPorId(id);
            return Ok(c);
        }
        
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Customer>> Post(Customer cliente)
        {
            var result =  await _customerService.Criar(cliente);
            return CreatedAtAction("Get", result);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> Put(int id, Customer cliente)
        {
            await _customerService.Atualizar(cliente);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> Delete(int id)
        {
            var cliente = await _customerService.Deletar(id);
            return NoContent();
        }

    }
}
