using FaunaDB.Query;
using Moq;
using FaunaDB.Types;
using Xunit;
using Moq;
using fauna_db_api.Repositories;
using fauna_db_api.Models;
using FaunaDB.Types;

namespace fauna_db_api.Test;

public class FaunaCarRepositoryTests
{
    [Fact]
    public async Task Add_Car_Success()
    {
        // Arrange
        var mockFaunaClientService = new Mock<IFaunaClientService>();
        var repository = new FaunaCarRepository(mockFaunaClientService.Object);
        var car = new Car(1, "Test Brand", "Test Model");

        // Set up the mock IFaunaClientService to return a Value object when Query is called
        mockFaunaClientService
            .Setup(service => service.Query(It.IsAny<Expr>()))
            .ReturnsAsync(Value.From(new
            {
                data = new
                {
                    id = car.Id,
                    brand = car.Brand,
                    model = car.Model
                }
            }));

        // Act
        var result = await repository.Add(car);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(car.Id, result.Id);
        Assert.Equal(car.Brand, result.Brand);
        Assert.Equal(car.Model, result.Model);
    }
}