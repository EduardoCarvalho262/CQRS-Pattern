using CustomerApplication.Commands.CustomerCommands;
using CustomerApplication.Handlers.CustomersHandlersCommands;
using CustomerDomain.Domain;
using CustomerInfra.Repositories;
using Moq;
using NUnit.Framework;
using System.Threading;

namespace CustomerUnitTests.Manipuladores.Commands.Customers
{
    public class DeleteCustomerTest
    {
        private Mock<IRepository<Customer>>? _mockRepository;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository<Customer>>();
            _mockRepository.Setup(r => r.Delete(It.IsAny<int>())).ReturnsAsync(new Customer {Id = 1, Name = "Teste", Phone = "11981169935" });
        }

        [Test]
        public void Delete_ObjetoCustomer_RetornaIdDeletado()
        {
            //Arrange
            var manipulador = new DeleteCustomerHandler(_mockRepository.Object);
            var comando = new DeleteCustomerCommand(1);
            var respostaEsperada = 1;

            //Act
            var response = manipulador.Handle(comando, new CancellationToken());

            //Assert
            Assert.NotNull(response);
            Assert.AreEqual(respostaEsperada, response.Id);
        }
    }
}
