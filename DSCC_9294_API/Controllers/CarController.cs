using DSCC_9294_API.IServices;
using DSCC_9294_API.Models;
using DSCC_9294_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSCC_9294_API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var cars = await _carService.GetAllAsync();
        return Ok(cars);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var car = await _carService.GetAsync(id);
        if (car == null)
        {
            return NotFound();
        }
        return Ok(car);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Car car)
    {
        if (car == null)
        {
            return BadRequest();
        }

        await _carService.CreateAsync(car);
        return CreatedAtAction(nameof(Get), new { id = car.Id }, car);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] Car car)
    {
        var res = await _carService.UpdateAsync(car);
        if (res == true)
        {
            return Ok("Updated");
        }
        return BadRequest(res);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var car = await _carService.GetAsync(id);
        if (car == null)
        {
            return NotFound();
        }

        await _carService.DeleteAsync(id);
        return NoContent();
    }
}