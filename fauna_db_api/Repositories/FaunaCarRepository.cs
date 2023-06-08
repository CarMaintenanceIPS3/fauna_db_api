﻿using fauna_db_api.FaunaDB;
using fauna_db_api.Models;
using FaunaDB.Client;
using FaunaDB.Types;
using static FaunaDB.Query.Language;

namespace fauna_db_api.Repositories;

public class FaunaCarRepository : IRepository<Car>
{
    private readonly IFaunaClientService _faunaClientService;

    public FaunaCarRepository(IFaunaClientService faunaClientService)
    {
        _faunaClientService = faunaClientService;
    }

    public async Task<Car> Add(Car car)
    {
        try
        {
            Value result = await _faunaClientService.Query(
                Create(
                    Collection("Cars"),
                    Obj("data",
                        Obj(
                            "id", $"{car.Id}",
                            "brand", $"{car.Brand}",
                            "model", $"{car.Model}",
                            "year", $"{car.Year}",
                            "kilometers", $"{car.Kilometers}"
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
            int year = data.At("year").To<int>().Value;
            int kilometers = data.At("kilometers").To<int>().Value;

            // Create a new Car object
            Car createdCar = new Car(id, brand, model, year, kilometers);

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

