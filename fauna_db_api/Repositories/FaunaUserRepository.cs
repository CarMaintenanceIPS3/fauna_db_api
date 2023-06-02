using fauna_db_api.FaunaDB;
using fauna_db_api.Models;
using FaunaDB.Client;
using FaunaDB.Types;
using static FaunaDB.Query.Language;

namespace fauna_db_api.Repositories;

public class FaunaUserRepository : IRepository<User>
{
    private readonly FaunaClient _faunaClient;

    public FaunaUserRepository(FaunaClientFactory faunaClientFactory)
    {
        _faunaClient = faunaClientFactory.CreateClient();
    }

    public async Task<User> Add(User user)
    {
        //try
        //{
        //Value result = await _faunaClient.Query(
        //    Create(
        //        Collection("users"),
        //        Obj("data",
        //            Obj(
        //                "firstName", $"{user.FirstName}",
        //                "lastName", $"{user.LastName}",
        //                "email", $"{user.Email}"
        //                )
        //        )
        //        )
        //    );
        //// Get the data from the result
        //var data = result.At("data");


        //// Extract the fields from the data
        //int id = data.At("id").To<int>().Value;
        //Car car = data.At("car").To<Car>().Value;
        //string firstName = data.At("firstName").To<string>().Value;
        //string lastName = data.At("lastName").To<string>().Value;
        //string email = data.At("email").To<string>().Value;

        //// Create a new Car object
        //User createdUser = new User(id, car, firstName, lastName, email);
        //Car createdCar = new Car(id, brand, model);

        //return createdCar;
        //}

        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex);
        //    throw;
        //}

        throw new NotImplementedException();

    }

    public Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Update(User entity)
    {
        throw new NotImplementedException();
    }
}

