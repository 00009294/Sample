using DSCC_9294_API.IServices;
using DSCC_9294_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSCC_9294_API.Controllers
{
    [Route("api/[controller]")]
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
            var Owners = await _ownerService.GetAllAsync();
            return Ok(Owners);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var owner = await _ownerService.GetAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            return Ok(owner);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Owner Owner)
        {
            if (Owner == null || id != Owner.Id)
            {
                return BadRequest();
            }

            var existingOwner = await _ownerService.GetAsync(id);
            if (existingOwner == null)
            {
                return NotFound();
            }

            await _ownerService.UpdateAsync(Owner);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Owner = await _ownerService.GetAsync(id);
            if (Owner == null)
            {
                return NotFound();
            }

            await _ownerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
