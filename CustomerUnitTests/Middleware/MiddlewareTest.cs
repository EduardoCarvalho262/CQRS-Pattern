using NUnit.Framework;

namespace CustomerUnitTests.Middleware;

public class MiddlewareTest
{
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void Test1()
    {
        //Arrange
        var controller = new CustomerController();
        
        
        //Act
        controller.Get();
        
        //Assert
    }
}