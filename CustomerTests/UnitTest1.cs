using CustomerApplication.Handlers.CustomersHandlersCommands;
using CustomerDomain.Domain;
using CustomerInfra.Repositories;
using CustomerService.Services;
using MediatR;
using NSubstitute;
using NUnit.Framework;

namespace CustomerTests
{
    public class Tests
    {

        private CustomerServiceC customerService;
        private Customer _customer;
        private IRepository<Customer> _repository;


        [SetUp]
        public void Setup()
        {
            var mediator = Substitute.For<IMediator>();
            _repository = Substitute.For<IRepository<Customer>>();
            _customer = new Customer { Id = 1, Name = "Teste", Phone = "41445907" };
            customerService = new CustomerServiceC(mediator);
        }

        [Test]
        public void ValidarManipuladorDeCriacaoDeCliente()
        {
            //Arrange
            _repository.Get(Arg.Any<int>()).Returns(_customer);

            //act
            var res  = customerService.ObterPorId(1);

            //assert
            Assert.IsNotNull(res);
            Assert.AreEqual(_customer.Id, res.Id);
        }
    }
}