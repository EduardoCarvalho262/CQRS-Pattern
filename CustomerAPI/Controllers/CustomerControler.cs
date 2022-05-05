using CustomerDomain.Domain;
using CustomerService.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaCustomers = await _customerService.ObterTodos();
                return Ok(listaCustomers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var customer = await _customerService.ObterPorId(id);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
        
        [HttpPost]
        public async Task<IActionResult> Post(Customer cliente)
        {
            try
            {
                var response = await _customerService.Criar(cliente);
                return CreatedAtAction("Get", response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Customer cliente)
        {
            try
            {
                var response = await _customerService.Atualizar(cliente);
                return Ok(response.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                
            var customer = await _customerService.Deletar(id);
            return Ok(customer.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
