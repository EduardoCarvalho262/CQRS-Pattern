using CustomerApplication.Commands.CustomerCommands;
using CustomerDomain.Domain;
using CustomerService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using CustomerApplication.Commands.UserCommands;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerControler : ControllerBase
    {
        private readonly ICustomerServices _customerService;
        private readonly IUserService _userService;

        public CustomerControler(ICustomerServices customerService, IUserService userService)
        {
            _customerService = customerService;
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var listaCustomers = await _customerService.ObterTodos();

            if (listaCustomers.Status != HttpStatusCode.OK.ToString())
                return NotFound(listaCustomers);

            return Ok(listaCustomers);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _customerService.ObterPorId(id);

            if (customer.Status != HttpStatusCode.OK.ToString())
                return NotFound(customer);

            return Ok(customer.Customers.FirstOrDefault());
        }
        
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post(CreateCustomerCommand cliente)
        {
            var response = await _customerService.Criar(cliente);

            if (response.Status != HttpStatusCode.Created.ToString())
                return BadRequest(response);

            return CreatedAtAction(nameof(Post), response);
        }
        
        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Put(UpdateCustomerCommand cliente)
        {
            var response = await _customerService.Atualizar(cliente);

            if (response.Status != HttpStatusCode.NoContent.ToString())
                return BadRequest(response);

            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerService.Deletar(id);

            if (customer.Status != HttpStatusCode.NoContent.ToString())
                return BadRequest(customer);

            return Ok(customer);
        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] AutheticateUserCommand model)
        {
            var user = await _userService.GetByUsernameAndPassword(model.Username, model.Password);

            if (user == null)
                return NotFound(new {message = "Usuário ou senha inválidos"});

            var token = TokenService.GenerateToken(user);

            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterUserCommand model)
        {
            var user = await _userService.GetByUsernameAndPassword(model.Username, model.Password);
            
            if (user is null)
            {
                var response = await _userService.Register(model);
                return Ok(new RegisterResponse { Message = "Usuário criado com sucesso" });
            }

            return Ok(new RegisterResponse { Message = "Usuário já cadastrado." });
        }
    }
}