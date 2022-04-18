using CustomerApplication.Commands.CustomerCommands;
using CustomerApplication.Handlers.CustomersHandlersCommands;
using CustomerDomain.Domain;
using CustomerInfra.Repositories;
using Moq;
using NUnit.Framework;
using System.Threading;

namespace CustomerUnitTests.Manipuladores.Commands.Customers
{
    public class UpdateCsutomerTest
    {
        private Mock<IRepository<Customer>>? _mockRepository;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IRepository<Customer>>();
            _mockRepository.Setup(f => f.Update(It.IsAny<Customer>())).ReturnsAsync(new Customer { Id = 1, Name = "TesteAtualizado", Phone = "11981169935" });
            _mockRepository.Setup(f => f.Get(It.IsAny<int>())).ReturnsAsync(new Customer { Id = 1, Name = "Teste", Phone = "11985092041" });
        }

        [Test]
        public void Verificar_ObjetoCustomer_RetonandoObjetoAtualizado()
        {
            //Arrange
            var manipulador = new UpdateCustomerHandler(_mockRepository.Object);
            var comando = new UpdateCustomerCommand(1, "TesteAtualizado", "11981169935");

            //Act
            var response = manipulador.Handle(comando, new CancellationToken());

            //Assert
            Assert.NotNull(response);
            Assert.AreEqual(1, response.Id);
            Assert.AreEqual(comando.Name, response.Result.Name);
            Assert.AreEqual(comando.Phone, response.Result.Phone);
        }
    }
}
