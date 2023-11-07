using DSCC_9294_API.IServices;
using DSCC_9294_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSCC_9294_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var owners = await _ownerService.GetAllAsync();
            return Ok(owners);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var owners = await _ownerService.GetAsync(id);
            if (owners == null)
            {
                return NotFound();
            }
            return Ok(owners);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Owner owner)
        {
            if (owner == null)
            {
                return BadRequest();
            }

            await _ownerService.CreateAsync(owner);
            return CreatedAtAction(nameof(Get), new { id = owner.Id }, owner);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Owner owner)
        {
            var res = await _ownerService.UpdateAsync(owner);
            if (res == true)
            {
                return Ok("updated");
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var owner = await _ownerService.GetAsync(id);
            if (owner == null)
            {
                return NotFound();
            }

            await _ownerService.DeleteAsync(id);
            return NoContent();
        }
    }
}