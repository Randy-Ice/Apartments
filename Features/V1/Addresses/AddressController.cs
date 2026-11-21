using Apartments.Data;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Apartments.Features.V1.Addresses.DTO
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ProjectDB _db;
        public AddressController(ProjectDB db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var address = await _db.Addresses.ToListAsync();
            return Ok(address.Adapt<IEnumerable<GetAddressDTO>>());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var address = await _db.Addresses.FirstOrDefaultAsync(x => x.Id == id);
            if (address == null)
            {
                return NotFound();
            }
            return Ok(address.Adapt<GetAddressDTO>());

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAddressDTO dto)
        {
            var address = dto.Adapt<Address>();
            await _db.AddAsync(address);
            await _db.SaveChangesAsync();
            var results = address.Adapt<GetAddressDTO>();
            return CreatedAtAction(nameof(GetById), new { id = address.Id }, results);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateAddressDTO dto)
        {
            var address = await _db.Addresses.FirstOrDefaultAsync(x => x.Id == id);
            if (address == null)
            {
                return NotFound();
            }
            dto.Adapt(address);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var address = await _db.Addresses.FirstOrDefaultAsync(x => x.Id == id);
            if (address == null)
            {
                return NotFound();
            }
            _db.Remove(address);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
