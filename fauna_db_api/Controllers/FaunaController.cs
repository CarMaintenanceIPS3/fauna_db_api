﻿using Microsoft.AspNetCore.Mvc;
using fauna_db_api.Models;
using Microsoft.AspNetCore.Authorization;
using fauna_db_api.Repositories;

namespace fauna_db_api.Controllers;

//[Authorize]
[ApiController]
[Route("[controller]")]
public class FaunaController : ControllerBase
{
    private readonly IRepository<Car> _carRepository;
    private readonly IRepository<User> _userRepository;

    public FaunaController(IRepository<Car> carRepository, IRepository<User> userRepository)
    {
        _carRepository = carRepository;
        _userRepository = userRepository;
    }

    // POST: CreateCar
    /// <summary>
    /// Creates a new car for the user in FaunaDB.
    /// </summary>
    /// <remarks>
    /// This should only be used when a user does not have a car in the database.
    /// </remarks>
    /// <param>Specifies the parameters</param>
    /// <response code="200">The car was successfully added to the user</response>
    /// <response code="400">An error was made with the given parameters. More context will be given in the body</response>
    [HttpPost("CreateCar")]
    public async Task<ActionResult<Car>> CreateCar([FromBody] Car car)
    {
        try
        {
            Car result = await _carRepository.Add(car);
            Console.WriteLine(result.ToString());

            return Ok(result);
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("CreateUser")]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        try
        {
            User result = await _userRepository.Add(user);
            Console.WriteLine(result.ToString());

            return Ok(result);
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return BadRequest(ex.Message);
        }
    }
}

