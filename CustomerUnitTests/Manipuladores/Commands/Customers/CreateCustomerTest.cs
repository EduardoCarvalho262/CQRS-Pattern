using CustomerApplication.Commands.CustomerCommands;
using CustomerApplication.Handlers.CustomersHandlersCommands;
using CustomerDomain.Domain;
using CustomerInfra.Repositories;
using Moq;
using NUnit.Framework;

namespace CustomerUnitTests.Manipuladores.Commands.Customers;

public class CreateCustomerTest
{
    private Mock<IRepository<Customer>>? _mockRepository;

    [SetUp]
    public void Setup()
    {
        _mockRepository = new Mock<IRepository<Customer>>();
        _mockRepository.Setup(r => r.Add(It.IsAny<Customer>())).ReturnsAsync(new Customer {Id = 1, Name = "Eduardo", Phone = "11985092041" });
    }

    [Test]
    public void Adiciona_ObjetoCustomer_RetornaObjetoCriado()
    {
        //Arrange
        var manipulador = new CreateCustomerHandler(_mockRepository.Object);
        var objeto = new CreateCustomerCommand(1, "Eduardo", "11985092041");

        //Act
        var response = manipulador.Handle(objeto, new System.Threading.CancellationToken());


        //Assert
        Assert.IsNotNull(response);
        Assert.AreEqual(objeto.Id, response.Result.Id);
        Assert.AreEqual(objeto.Name, response.Result.Name);
        Assert.AreEqual(objeto.Phone, response.Result.Phone);
    }
}