using fauna_db_api.FaunaDB;
using fauna_db_api.Models;
using FaunaDB.Client;
using FaunaDB.Types;
using static FaunaDB.Query.Language;

namespace fauna_db_api.Repositories;

public class FaunaCarRepository : IRepository<Car>
{
    private readonly FaunaClient _faunaClient;

    public FaunaCarRepository(FaunaClientFactory faunaClientFactory)
    {
        _faunaClient = faunaClientFactory.CreateClient();
    }

    public async Task<Car> Add(Car car)
    {
        try
        {
            Value result = await _faunaClient.Query(
                Create(
                    Collection("Cars"),
                    Obj("data",
                        Obj(
                            "id", $"{car.Id}",
                            "brand", $"{car.Brand}",
                            "model", $"{car.Model}"
                            )
                    )
                    )
                );
            // Get the data from the result
            var data = result.At("data");

            // Extract the fields from the data
            int id = data.At("id").To<int>().Value;
            string brand = data.At("brand").To<string>().Value;
            string model = data.At("model").To<string>().Value;

            // Create a new Car object
            Car createdCar = new Car(id, brand, model);

            return createdCar;
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Car> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Car>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Update(Car entity)
    {
        throw new NotImplementedException();
    }
}

